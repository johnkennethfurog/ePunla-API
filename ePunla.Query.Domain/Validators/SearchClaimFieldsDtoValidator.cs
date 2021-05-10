using System;
using ePunla.Query.Domain.Dtos;
using FluentValidation;

namespace ePunla.Query.Domain.Validators
{
    public class SearchClaimFieldsDtoValidator : AbstractValidator<SearchClaimFieldsDto>
    {
        public SearchClaimFieldsDtoValidator() 
        {
            RuleFor(x => x.Status)
                .IsInEnum()
                .When(x => x.Status != null);
        }
    }
}
