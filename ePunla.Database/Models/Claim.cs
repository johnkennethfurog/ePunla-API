using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePunla.Common.Database.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }
        [ForeignKey("FarmCropId")]
        public FarmCrop FarmCrop { get; set; }
        [ForeignKey("FarmId")]
        public Farm Farm { get; set; }
        public DateTime FilingDate { get; set; }
        public string DamagedArea { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int PhotoId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public DateTime ValidationDate { get; set; }
    }
}
