using System;
namespace ePunla.Common.Utilitites.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string userId);
    }
}
