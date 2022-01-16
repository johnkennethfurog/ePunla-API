using System;
namespace ePunla.Query.DAL.Models
{
    public class CropsOccuranceModel
    {
        public string Crop { get; set; }
        public string PlantedDate { get; set; }
        public int AreaSize { get; set; }
        public string Farm { get; set; }
        public string Farmer { get; set; }
    }
}
