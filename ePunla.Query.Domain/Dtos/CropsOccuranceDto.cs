using System;
namespace ePunla.Query.Domain.Dtos
{
    public class CropsOccuranceDto
    {
        public string Crop { get; set; }
        public string PlantedDate { get; set; }
        public int AreaSize { get; set; }
        public string Farm { get; set; }
        public string Farmer { get; set; }
    }
}

