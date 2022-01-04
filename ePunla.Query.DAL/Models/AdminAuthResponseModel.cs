namespace ePunla.Query.DAL.Models
{
    public class AdminAuthResponseModel
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
