using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePunla.Common.Database.Models
{
    public class Crop
    {
        [Key]
        public int CropId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
    }
}
