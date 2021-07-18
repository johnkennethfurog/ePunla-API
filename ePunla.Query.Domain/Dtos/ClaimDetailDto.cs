using System;
using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class ClaimDetailDto
    {
        // CLAIM DETAIL
        public int ClaimId { get; set; }
        public DateTime FilingDate { get; set; }
        public string DamagedArea { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Remarks { get; set; }
        public DateTime? ValidationDate { get; set; }
        public IEnumerable<ClaimDamageCauseDto> DamageCause { get; set; }
        public int TotalDamagedArea { get; set; }

        // CROP DETAIL
        public string Crop { get; set; }
        public DateTime DatePlanted { get; set; }
        public int CropAreaSize { get; set; }

        // FARM DETAIL
        public string Farm { get; set; }
        public string Address { get; set; }
        public string Barangay { get; set; }
        public string Area { get; set; }
        public int FarmSize { get; set; }

        // FARMER DETAIL
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Avatar { get; set; }
        public string MobileNumber { get; set; }
        public string FamerBarangay { get; set; }
        public string FarmerArea { get; set; }
        public string FarmerAddress { get; set; }
    }
}
