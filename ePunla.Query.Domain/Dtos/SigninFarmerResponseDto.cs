using System;
namespace ePunla.Query.Domain.Dtos
{
    public class SigninFarmerResponseDto
    {
        public string Token { get; set; }
        public FarmerInfoDto User { get; set; }
    }
}
