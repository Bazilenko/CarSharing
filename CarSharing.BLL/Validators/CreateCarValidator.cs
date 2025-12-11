using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Car;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.Make).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();

            RuleFor(x => x.LicensePlate)
                .NotEmpty()
                .Length(3, 10).WithMessage("Номерний знак має бути коректним (3-10 символів)");

            RuleFor(x => x.VinCode)
                .NotEmpty()
                .Length(17).WithMessage("VIN-код повинен містити рівно 17 символів");

            RuleFor(x => x.Year)
                .GreaterThan(1990).WithMessage("Авто занадто старе (пізніше 1990)")
                .LessThanOrEqualTo(DateTime.Now.Year + 1).WithMessage("Некоректний рік випуску");

            RuleFor(x => x.PricePerDay)
                .GreaterThan(0).WithMessage("Ціна має бути більше 0");

            RuleFor(x => x.Transmission)
                .Must(t => t == "Automatic" || t == "Manual")
                .WithMessage("Трансмісія: 'Automatic' або 'Manual'");
        }
    }
}
