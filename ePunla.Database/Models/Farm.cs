using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ePunla.Common.Database.Models
{
    public class Farm
    {
        [Key]
        public int FarmId { get; set; }
        [ForeignKey("FarmerId")]
        public Farmer Farmer { get; set; }
        public string Address { get; set; }
        [ForeignKey("BarangayId")]
        public Barangay Barangay { get; set; }
        [ForeignKey("BarangayAreaId")]
        public BarangayArea BarangayArea { get; set; }
        public int AreaSize { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        // public Point GeoLocation { get; set; }
    }
}
