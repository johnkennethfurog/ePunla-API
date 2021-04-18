using System;
using System.ComponentModel.DataAnnotations;

namespace ePunla.Common.Database.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
