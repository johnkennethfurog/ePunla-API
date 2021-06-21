using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class BarangayDto
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<AreaDto> Areas { get; set; }
    }
}
