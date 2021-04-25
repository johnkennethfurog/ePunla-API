using System;
namespace ePunla.Query.Domain.Dtos
{
    public class FarmDto
    {
        public int FarmId { get; set; }
        public string Name { get; set; }
        public decimal AreaSize { get; set; }
        public string Status { get; set; }
        public string Barangay { get; set; }
        public int BarangayId { get; set; }
        public string BarangayArea { get; set; }
        public int BarangayAreaId { get; set; }
        public string StreetAddress { get; set; }

    }
}
