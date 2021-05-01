using System;
using ePunla.Command.Domain.Dtos;
using FluentValidation;

namespace ePunla.Command.Domain.Validators
{
    public class SaveClaimDtoValidator : AbstractValidator<SaveClaimDto>
    {
        public SaveClaimDtoValidator()
        {
            RuleFor(x => x.ClaimId)
                .GreaterThan(0)
                .When(x => x.ClaimId != null);

            RuleFor(x => x.DamagedArea)
                .Must(damagedArea => damagedArea.ToUpper() == "PARTIAL" || damagedArea.ToUpper() == "FULL");

            RuleFor(x => x.FarmCropId)
                .NotEmpty();

            RuleFor(x => x.ClaimCauses)
               .NotEmpty();

            RuleForEach(x => x.ClaimCauses)
                .SetValidator(new DamageCauseDtoValidator());
        }
    }
}
