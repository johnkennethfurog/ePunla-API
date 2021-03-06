using System;
namespace ePunla.Query.DAL.Models
{
    public class FarmerClaimModel
    {
        public int ClaimId { get; set; }
        public DateTime FilingDate { get; set; }
        public string Crop { get; set; }
        public string Farm { get; set; }
        public string DamagedArea { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string ReferenceNumber { get; set; }

        public int FarmCropId { get; set; }
        public int FarmId { get; set; }
        public string PhotoId { get; set; }
        public DateTime? ValidationDate { get; set; }
    }
}
