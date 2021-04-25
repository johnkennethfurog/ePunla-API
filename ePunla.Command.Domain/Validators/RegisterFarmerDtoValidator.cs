using System;
using ePunla.Command.Domain.Dtos;
using FluentValidation;

namespace ePunla.Command.Domain.Validators
{
    public class RegisterFarmerDtoValidator : AbstractValidator<RegisterFarmerDto>
    {
        public RegisterFarmerDtoValidator()
        {
            RuleFor(x => x.MobileNumber)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.BarangayAreaId)
                .NotEmpty();

            RuleFor(x => x.BarangayId)
                .NotEmpty();

            RuleFor(x => x.StreetAddress)
                .NotEmpty();
        }
    }
}
