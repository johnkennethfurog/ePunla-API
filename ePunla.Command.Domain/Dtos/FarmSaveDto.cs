namespace ePunla.Command.Domain.Dtos
{
    public class FarmSaveDto
    {
        public int? FarmId { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string StreetAddress { get; set; }
        public int BarangayId { get; set; }
        public int BarangayAreaId { get; set; }
        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
    }
}
