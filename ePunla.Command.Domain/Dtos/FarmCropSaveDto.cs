using System;
namespace ePunla.Command.Domain.Dtos
{
    public class FarmCropSaveDto
    {
        public int? FarmCropId { get; set; }
        public int FarmId { get; set; }
        public int CropId { get; set; }
        public DateTime DatePlanted { get; set; }
        public decimal AreaSize { get; set; }
    }
}
