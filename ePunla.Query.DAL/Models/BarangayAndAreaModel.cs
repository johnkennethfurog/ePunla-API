namespace ePunla.Query.DAL.Models
{
    public class BarangayAndAreaModel
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public int BarangayAreaId { get; set; }
        public string Area { get; set; }
        public bool IsActive { get; set; }
        public bool AreaIsActive { get; set; }
    }
}
