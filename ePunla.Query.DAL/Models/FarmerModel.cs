namespace ePunla.Query.DAL.Models
{
    public class FarmerModel
    {
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }
        public string StreetAddress { get; set; }
        public int BarangayAreaId { get; set; }
        public int BarangayId { get; set; }
        public string MobileNumber { get; set; }
        public string AvatarId { get; set; }
    }
}
