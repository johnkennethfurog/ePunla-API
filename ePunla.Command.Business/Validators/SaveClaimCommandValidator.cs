using System;
using ePunla.Command.Business.Commands;
using ePunla.Command.Domain.Validators;
using FluentValidation;

namespace ePunla.Command.Business.Validators
{
    public class SaveClaimCommandValidator : AbstractValidator<SaveClaimCommand>
    {
        public SaveClaimCommandValidator()
        {
            RuleFor(x => x.SaveClaimDto)
                .NotNull();

            RuleFor(x => x.SaveClaimDto)
               .SetValidator(new SaveClaimDtoValidator());
        }
    }
}
