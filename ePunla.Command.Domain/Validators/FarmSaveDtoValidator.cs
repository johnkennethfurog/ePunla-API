using ePunla.Command.Domain.Dtos;
using FluentValidation;

namespace ePunla.Command.Domain.Validators
{
    public class FarmSaveDtoValidator : AbstractValidator<FarmSaveDto>
    {
        public FarmSaveDtoValidator()
        {
            RuleFor(x => x.FarmId)
                .GreaterThan(0)
                .When(x => x.FarmId != null);

            RuleFor(x => x.BarangayAreaId)
                .NotEmpty();

            RuleFor(x => x.Name)
               .NotEmpty();

            RuleFor(x => x.StreetAddress)
              .NotEmpty();

            RuleFor(x => x.BarangayId)
                .NotEmpty();

            RuleFor(x => x.Size)
               .NotEmpty();

        }
    }
}
