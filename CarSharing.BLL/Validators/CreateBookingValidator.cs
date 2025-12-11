using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Booking;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
        public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
        {
            public CreateBookingValidator()
            {
                RuleFor(x => x.CarId).GreaterThan(0);

                // 1. Початок не в минулому
                RuleFor(x => x.StartTime)
                    .GreaterThan(DateTime.Now.AddMinutes(5)) // Хоча б за 5 хв наперед
                    .WithMessage("Час початку не може бути в минулому");

                // 2. Кінець пізніше початку
                RuleFor(x => x.EndTime)
                    .GreaterThan(x => x.StartTime)
                    .WithMessage("Час завершення має бути пізніше часу початку");

                // 3. Мінімальна тривалість оренди (наприклад, 1 година)
                RuleFor(x => x)
                    .Must(x => (x.EndTime - x.StartTime).TotalHours >= 1)
                    .WithMessage("Мінімальний термін оренди - 1 година");

        }
    }
}
