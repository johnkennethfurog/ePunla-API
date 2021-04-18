using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ePunla.Common.Database.Models
{
    public class Barangay
    {
        [Key]
        public int BarangayId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
