using ePunla.Command.Business.Commands;
using ePunla.Command.Domain.Validators;
using FluentValidation;

namespace ePunla.Command.Business.Validators
{
    public class SaveFarmCommandValidator : AbstractValidator<SaveFarmCommand>
    {
        public SaveFarmCommandValidator()
        {
            RuleFor(x => x.FarmSaveDto)
               .NotNull();

            RuleFor(x => x.FarmSaveDto)
                .SetValidator(new FarmSaveDtoValidator());
        }
    }
}
