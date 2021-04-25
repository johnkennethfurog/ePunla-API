using System;
using ePunla.Query.Domain.Enums;

namespace ePunla.Query.Domain.Dtos
{
    public class SearchCropFieldsDto
    {
        public CropStatus? Status { get; set; }
        public int? CropId { get; set; }
        public DateTime? PlantedFrom { get; set; }
        public DateTime? PlantedTo { get; set; }
    }
}
