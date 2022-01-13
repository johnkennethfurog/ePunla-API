using System;
namespace ePunla.Query.DAL.Models
{
    public class FarmerPerBarangayModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string Barangay { get; set; }
        public string MobileNumber { get; set; }
        public int BarangayId { get; set; }
        public int FarmerId { get; set; }
    }
}
