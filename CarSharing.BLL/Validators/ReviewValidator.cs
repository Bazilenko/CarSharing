using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Review;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.BookingId).GreaterThan(0);

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Оцінка має бути від 1 до 5");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Напишіть коментар")
                .MaximumLength(500).WithMessage("Коментар занадто довгий (макс 500 символів)");
        }
    }
}
