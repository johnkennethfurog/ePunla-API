using System;
namespace ePunla.Query.DAL.Models
{
    public class FarmCropModel
    {
        public int FarmCropId { get; set; }
        public string Crop { get; set; }
        public int CropId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int FarmId { get; set; }
        public string Farm { get; set; }
        public DateTime EstimatedHarvestDate { get; set; }
        public DateTime PlantedDate { get; set; }
        public decimal AreaSize { get; set; }
        public string Status { get; set; }
        public DateTime HarvestDate { get; set; }
    }
}
