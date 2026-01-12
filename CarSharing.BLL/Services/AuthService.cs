using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs;
using CarSharing.BLL.DTOs.User;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarSharing.BLL.Services
{
    using CarSharing.BLL.Exceptions; 

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService; 
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            if (await _userRepository.EmailExistsAsync(dto.Email))
                
                throw new BadRequestException("Користувач з таким Email вже існує.");

            var user = _mapper.Map<User>(dto);

            
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

           

            await _userRepository.AddAsync(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

           
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                
                throw new UnauthorizedAccessException("Невірний Email або пароль.");
            }

            
            var token = _tokenService.GenerateAccessToken(user);
            var userDto = _mapper.Map<UserDto>(user);

            return new AuthResponseDto
            {
                Token = token,
                User = userDto
            };
        }
    }
}
