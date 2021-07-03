namespace ePunla.Query.DAL.Models
{
    public class CropModel
    {
        public int total_count { get; set; }
        public int CropId { get; set; }
        public string Crop { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
    }
}
