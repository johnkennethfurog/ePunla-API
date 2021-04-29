namespace ePunla.Query.Domain.Dtos
{
    public class ClaimDamageCauseDto
    {
        public int ClaimCauseId { get; set; }
        public string DamageType { get; set; }
        public decimal DamagedAreaSize { get; set; }
        public int DamageTypeId { get; set; }
    }
}
