using System.Collections.Generic;

namespace ePunla.Command.Domain.Dtos
{
    public class SaveClaimDto
    {
        public int? ClaimId { get; set; }
        public int FarmCropId { get; set; }
        public string DamagedArea { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoId { get; set; }

        public IEnumerable<DamageCauseDto> ClaimCauses { get; set; }
    }
}
