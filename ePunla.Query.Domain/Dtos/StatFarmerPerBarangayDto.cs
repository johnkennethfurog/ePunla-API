using System;
namespace ePunla.Query.Domain.Dtos
{
    public class StatFarmerPerBarangayDto
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public int FarmerCount { get; set; }
    }
}
