namespace ePunla.Query.Domain.Dtos
{
    public class CropDto
    {
        public int CropId { get; set; }
        public string Crop { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
    }
}
