using ePunla.Query.Business.AdminQueries;
using ePunla.Query.Domain.Validators;
using FluentValidation;

namespace ePunla.Query.Business.Validators
{
    public class GetClaimsQueryValidator : AbstractValidator<GetClaimsQuery>
    {
        public GetClaimsQueryValidator()
        {
            RuleFor(x => x.SearchRequest)
                .NotNull();

            RuleFor(x => x.SearchRequest.SearchField)
                .SetValidator(new SearchAdminClaimFieldsDtoValidator());

            RuleFor(x => x.SearchRequest.Page)
              .SetValidator(new PageRequestValidator());
        }
    }
}
