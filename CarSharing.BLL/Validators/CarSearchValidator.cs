using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Car;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
    public class CarSearchValidator : AbstractValidator<CarSearchDto>
    {
        public CarSearchValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(50);

            
            RuleFor(x => x.MinPrice)
                .GreaterThanOrEqualTo(0).When(x => x.MinPrice.HasValue);

            
            RuleFor(x => x.MaxPrice)
                .GreaterThanOrEqualTo(x => x.MinPrice.Value)
                .When(x => x.MaxPrice.HasValue && x.MinPrice.HasValue)
                .WithMessage("Максимальна ціна має бути більшою за мінімальну");

            
            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now).When(x => x.StartDate.HasValue)
                .WithMessage("Дата початку має бути в майбутньому");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate.Value)
                .When(x => x.EndDate.HasValue && x.StartDate.HasValue)
                .WithMessage("Дата завершення має бути пізніше дати початку");
        }
    }
}
