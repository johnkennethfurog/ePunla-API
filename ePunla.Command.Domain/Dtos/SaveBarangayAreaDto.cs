using System;
namespace ePunla.Command.Domain.Dtos
{
    public class SaveBarangayAreaDto
    {
        public int? BarangayAreaId { get; set; }
        public string Area { get; set; }
        public bool AreaIsActive { get; set; }
    }
}
