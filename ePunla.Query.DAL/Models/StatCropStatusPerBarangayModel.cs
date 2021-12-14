using System;
using ePunla.Query.Domain.Enums;

namespace ePunla.Query.DAL.Models
{
    public class StatCropStatusPerBarangayModel
    {
        public int BarangayId { get; set; }
        public int CropsCount { get; set; }
        public string Barangay { get; set; }
        public string Status { get; set; }
    }
}
