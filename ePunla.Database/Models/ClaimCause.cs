using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePunla.Common.Database.Models
{
    public class ClaimCause
    {
        [Key]
        public int ClaimCauseId { get; set; }
        [ForeignKey("ClaimId")]
        public Claim Claim { get; set; }
        public string DamageType { get; set; }
        public int DamagedAreaSize { get; set; }
    }
}
