using System;
namespace ePunla.Query.DAL.Models
{
    public class FarmModel
    {
        public int total_count { get; set; }
        public int FarmId { get; set; }
        public string Farm { get; set; }
        public string Barangay { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public decimal AreaSize { get; set; }
        public string IdentityDocumentUrl { get; set; }
        public string IdentityDocumentId { get; set; }
        public DateTime? ValidationDate { get; set; }

        public int FarmerId { get; set; }
        public string Farmer { get; set; }
        public string MobileNumber { get; set; }
        public string Avatar { get; set; }
        public string FarmerStatus { get; set; }
        public string FarmerBarangay { get; set; }
        public string FarmerArea { get; set; }
        public string FarmerAddress { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlId { get; set; }
    }
}
