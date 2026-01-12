using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Document;
using FluentValidation;

namespace CarSharing.BLL.Validators
{
    public class UploadDocumentValidator : AbstractValidator<UploadDocumentDto>
    {
        public UploadDocumentValidator()
        {
            RuleFor(x => x.Type)
                .Must(t => t == "DriverLicense" || t == "Passport")
                .WithMessage("Тип документа має бути 'DriverLicense' або 'Passport'");

            RuleFor(x => x.File)
                .NotNull().WithMessage("Файл не вибрано")
                .Must(file => file.Length > 0 && file.Length < 5 * 1024 * 1024)
                .WithMessage("Розмір файлу має бути до 5 МБ")
                .Must(file =>
                    file.ContentType.Equals("image/jpeg") ||
                    file.ContentType.Equals("image/png") ||
                    file.ContentType.Equals("application/pdf"))
                .WithMessage("Дозволені формати: JPG, PNG, PDF");
        }
    }
}
