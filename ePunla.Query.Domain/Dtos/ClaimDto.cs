using System;
using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class ClaimDto
    {
        public int ClaimId { get; set; }
        public DateTime FilingDate { get; set; }
        public string Crop { get; set; }
        public string DamagedArea { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Remarks { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string ReferenceNumber { get; set; }

        public string Farm { get; set; }
        public string Address { get; set; }
        public string Barangay { get; set; }
        public string Area { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Avatar { get; set; }
        public string MobileNumber { get; set; }

        public IEnumerable<ClaimDamageCauseDto> DamageCause { get; set; }
    }
}
