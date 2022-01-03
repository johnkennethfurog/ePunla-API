using System;
namespace ePunla.Query.Domain.Dtos
{
    public class FarmerDashboardCropStatDto
    {
        public int CropId { get; set; }
        public string Name { get; set; }
        public int AreaSize { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
    }
}
