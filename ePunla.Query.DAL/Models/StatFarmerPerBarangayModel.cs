using System;
namespace ePunla.Query.DAL.Models
{
    public class StatFarmerPerBarangayModel
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public int FarmerCount { get; set; }
    }
}
