using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Поле для пошти не може бути порожнім!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Поле для паролю не може бути порожнім!");
        }
    }
}
