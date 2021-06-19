using System;
using ePunla.Query.Domain.Dtos;
using FluentValidation;

namespace ePunla.Query.Domain.Validators
{
    public class PageRequestValidator : AbstractValidator<PageRequest>
    {
        public PageRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
