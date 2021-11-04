using System;
namespace ePunla.Command.Domain.Dtos
{
    public class RegisterFarmerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetAddress { get; set; }
        public int BarangayId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string AvatarId { get; set; }
        public int BarangayAreaId { get; set; }
        public string IdentityDocumentUrl { get; set; }
        public string IdentityDocumentId { get; set; }
    }
}
