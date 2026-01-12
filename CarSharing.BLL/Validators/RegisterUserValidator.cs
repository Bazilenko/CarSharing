using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email є обов'язковим")
                .EmailAddress().WithMessage("Некоректний формат Email");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ім'я обов'язкове")
                .MaximumLength(50).WithMessage("Ім'я занадто довге");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Прізвище обов'язкове")
                .MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6).WithMessage("Пароль має бути не менше 6 символів");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?380\d{9}$").WithMessage("Телефон має бути у форматі +380xxxxxxxxx");

            
            RuleFor(x => x.BirthDate)
                .Must(BeOver18).WithMessage("Реєстрація дозволена тільки особам старше 18 років");
        }

        private bool BeOver18(DateTime birthDate)
        {
            return DateTime.Today.AddYears(-18) >= birthDate;
        }
    }
}
