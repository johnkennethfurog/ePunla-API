using System;
using ePunla.Query.Domain.Enums;

namespace ePunla.Query.Domain.Dtos
{
    public class StatCropStatusPerBarangayDto
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public int Planted { get; set; }
        public int Damaged { get; set; }
        public int Harvested { get; set; }
    }

}
