using System;
using ePunla.Query.Business.Queries;
using ePunla.Query.Domain.Validators;
using FluentValidation;

namespace ePunla.Query.Business.Validators
{
    public class GetFarmersCropQueryValidator : AbstractValidator<GetFarmersCropQuery>
    {
        public GetFarmersCropQueryValidator()
        {
            RuleFor(x => x.FarmerId)
                .NotEmpty();

            RuleFor(x => x.SearchField)
                .NotNull();

            RuleFor(x => x.SearchField)
                .SetValidator(new SearchCropFieldsDtoValidator());
        }
    }
}
