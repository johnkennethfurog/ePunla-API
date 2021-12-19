using System;
namespace ePunla.Query.Domain.Dtos
{
    public class StatCountDto
    {
        public int FarmCount { get; set; }
        public int ActiveFarmerCount { get; set; }
        public int PlantedCropsSqm { get; set; }
        public int HarvestedCropsSqm { get; set; }
        public int DamagedCropsSqm { get; set; }
    }
}
