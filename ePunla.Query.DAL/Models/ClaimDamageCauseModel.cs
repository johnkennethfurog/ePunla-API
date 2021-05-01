using System;
namespace ePunla.Query.DAL.Models
{
    public class ClaimDamageCauseModel
    {
        public string DamageType { get; set; }
        public decimal DamagedAreaSize { get; set; }
        public int ClaimId { get; set; }
        public int DamageTypeId { get; set; }
    }
}
