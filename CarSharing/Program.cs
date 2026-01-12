using System;
using System.Text;
using AutoMapper;
using CarSharing.BLL.Mappers;
using CarSharing.BLL.Services;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.BLL.Validators;
using CarSharing.DAL.Context;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository;
using CarSharing.DAL.Repository.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        }));

builder.Services.AddAuthentication(options =>
{
    // Обов'язково вказуємо дефолтні схеми!
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin",
        policy => policy.WithOrigins("https://localhost:7276") 
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IGenericRepository<CarImage>, GenericRepository<CarImage>>();

builder.Services.AddAutoMapper(typeof(BookingProfile));
builder.Services.AddAutoMapper(typeof(CarProfile));
builder.Services.AddAutoMapper(typeof(ReviewProfile));
builder.Services.AddAutoMapper(typeof(UserProfile));


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7276/") 
});


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarSharing API", Version = "v1" });

    // 1. Визначаємо, як вводити токен (додаємо кнопку "Authorize")
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Введіть токен доступу. Приклад: 'Bearer eyJhb...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // 2. Кажемо Swagger-у використовувати цю схему для всіх запитів
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowBlazorOrigin");
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub(); 
app.MapFallbackToPage("/_Host");

app.Run();
