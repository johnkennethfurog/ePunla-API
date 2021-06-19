using System;
namespace ePunla.Command.Domain.Dtos
{
    public class SaveCropDto
    {
        public int? CropId { get; set; }
        public int CategoryId { get; set; }
        public string Crop { get; set; }
        public int Duration { get; set; }
    }
}
