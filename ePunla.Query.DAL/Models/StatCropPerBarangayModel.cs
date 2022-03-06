using System;
namespace ePunla.Query.DAL.Models
{
    public class StatCropPerBarangayModel
    {
        public int CropId { get; set; }
        public int BarangayId { get; set; }
        public int CropsCount { get; set; }
        public string Crop { get; set; }
        public string Barangay { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string Color { get; set; }
    }
}
