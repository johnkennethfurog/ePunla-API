namespace ePunla.Query.DAL.Models
{
    public class FarmerAuthResponseModel
    {
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Avatar { get; set; }
    }
}
