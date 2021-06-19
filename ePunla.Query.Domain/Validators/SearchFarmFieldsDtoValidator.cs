using System;
using ePunla.Query.Domain.Dtos;
using FluentValidation;

namespace ePunla.Query.Domain.Validators
{
    public class SearchFarmFieldsDtoValidator : AbstractValidator<SearchFarmFieldsDto>
    {
        public SearchFarmFieldsDtoValidator()
        {
            RuleFor(x => x.BarangayId)
                .GreaterThan(0)
                .When(x => x.BarangayId != null);

            RuleFor(x => x.Status)
                .IsInEnum();

        }
    }
}
