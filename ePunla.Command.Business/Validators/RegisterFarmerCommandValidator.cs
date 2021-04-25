using System;
using ePunla.Command.Business.Commands;
using ePunla.Command.Domain.Validators;
using FluentValidation;

namespace ePunla.Command.Business.Validators
{
    public class RegisterFarmerCommandValidator : AbstractValidator<RegisterFarmerCommand>
    {
        public RegisterFarmerCommandValidator()
        {
            RuleFor(x => x.RegisterFarmerDto)
                .SetValidator(new RegisterFarmerDtoValidator());
        }
    }
}
