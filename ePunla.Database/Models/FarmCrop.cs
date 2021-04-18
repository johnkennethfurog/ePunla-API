using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePunla.Common.Database.Models
{
    public class FarmCrop
    {
        [Key]
        public int FarmCropId { get; set; }
        [ForeignKey("CropId")]
        public Crop Crop { get; set; }
        [ForeignKey("FarmId")]
        public Farm Farm { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public DateTime EstimatedHarvestDate { get; set; }
        public DateTime PlantedDate { get; set; }
        public int AreaSize { get; set; }
        public string Status { get; set; }
        public DateTime HarvestDate { get; set; }
    }
}
