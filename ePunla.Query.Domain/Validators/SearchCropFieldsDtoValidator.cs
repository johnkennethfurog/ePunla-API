using System;
using ePunla.Query.Domain.Dtos;
using FluentValidation;

namespace ePunla.Query.Domain.Validators
{
    public class SearchCropFieldsDtoValidator : AbstractValidator<SearchCropFieldsDto>
    {
        public SearchCropFieldsDtoValidator()
        {
            RuleFor(x => x.PlantedFrom)
                .LessThan(x => x.PlantedTo)
                .When(x => x.PlantedFrom != null && x.PlantedTo != null);

            RuleFor(x => x.CropId)
                .GreaterThan(0)
                .When(x => x.CropId != null);

            RuleFor(x => x.Status)
                .IsInEnum()
                .When(x => x.Status != null);
        }
    }
}
