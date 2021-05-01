using System;
using ePunla.Command.Domain.Dtos;
using FluentValidation;

namespace ePunla.Command.Domain.Validators
{
    public class DamageCauseDtoValidator : AbstractValidator<DamageCauseDto>
    {
        public DamageCauseDtoValidator()
        {
            RuleFor(x => x.DamageTypeId)
                .IsInEnum();

            RuleFor(x => x.DamagedAreaSize)
                .GreaterThanOrEqualTo(0);
        }
    }
}
