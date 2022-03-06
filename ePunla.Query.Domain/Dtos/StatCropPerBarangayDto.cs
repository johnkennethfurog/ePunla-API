using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class StatCropPerBarangayDto
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public IEnumerable<StatCrop> Crops { get; set; }
        public int TotalCount { get; set; }
    }

    public class StatCrop
    {
        public string Crop { get; set; }
        public decimal Percentage { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }
    }
}
