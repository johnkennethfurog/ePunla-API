using ePunla.Query.Business.AdminQueries;
using ePunla.Query.Domain.Dtos;
using ePunla.Query.Domain.Validators;
using FluentValidation;

namespace ePunla.Query.Business.Validators
{
    public class GetFarmsQueryValidator : AbstractValidator<GetFarmsQuery>
    {
        public GetFarmsQueryValidator()
        {
            RuleFor(x => x.SearchRequest)
                .NotNull();

            RuleFor(x => x.SearchRequest.SearchField)
                .SetValidator(new SearchFarmFieldsDtoValidator());

            RuleFor(x => x.SearchRequest.Page)
              .SetValidator(new PageRequestValidator());
        }
    }
}
