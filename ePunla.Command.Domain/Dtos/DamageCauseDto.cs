using ePunla.Command.Domain.Enums;

namespace ePunla.Command.Domain.Dtos
{
    public class DamageCauseDto
    {
        public DamageType DamageTypeId { get; set; }
        public decimal DamagedAreaSize { get; set; }
    }
}
