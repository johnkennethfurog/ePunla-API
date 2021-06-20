using System;
using System.Collections.Generic;

namespace ePunla.Command.Domain.Dtos
{
    public class SaveBarangayDto
    {
        public int? BarangayId { get; set; }
        public string BarangayName { get; set; }
        public IEnumerable<SaveBarangayAreaDto> Areas { get; set; }
    }
}
