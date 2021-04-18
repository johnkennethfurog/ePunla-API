using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePunla.Common.Database.Models
{
    public class BarangayArea
    {
        [Key]
        public int BarangayAreaId { get; set; }
        [ForeignKey("BarangayId")]
        public Barangay Barangay  { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
