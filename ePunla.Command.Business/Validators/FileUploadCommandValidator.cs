using System;
using ePunla.Command.Business.Commands;
using FluentValidation;

namespace ePunla.Command.Business.Validators
{
    public class FileUploadCommandValidator : AbstractValidator<FileUploadCommand>
    {
        public FileUploadCommandValidator()
        {
            RuleFor(x => x.FormFile)
                .Must(x => x.Length > 0);
        }
    }
}
