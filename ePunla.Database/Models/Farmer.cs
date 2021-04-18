using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePunla.Common.Database.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int AvatarId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public DateTime ValidationDate { get; set; }
        public string Remarks { get; set; }

        [ForeignKey("BarangayId")]
        public Barangay Barangay { get; set; }
        [ForeignKey("BarangayAreaId")]
        public BarangayArea BarangayArea { get; set; }

    }
}
