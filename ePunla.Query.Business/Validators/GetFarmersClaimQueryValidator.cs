using System;
using ePunla.Query.Business.Queries;
using ePunla.Query.Domain.Validators;
using FluentValidation;

namespace ePunla.Query.Business.Validators
{
    public class GetFarmersClaimQueryValidator : AbstractValidator<GetFarmersClaimQuery>
    {
        public GetFarmersClaimQueryValidator()
        {
            RuleFor(x => x.SearchField)
                .NotNull();

            RuleFor(x => x.SearchField)
                .SetValidator(new SearchClaimFieldsDtoValidator());
        }
    }
}
