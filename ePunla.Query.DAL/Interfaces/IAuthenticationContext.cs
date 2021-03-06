using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Models;

namespace ePunla.Query.DAL.Interfaces
{
    public interface IAuthenticationContext
    {
        Task<ContextResponse<FarmerAuthResponseModel>> AuthenticateFarmer(string mobileNumber);
        Task<ContextResponse<AdminAuthResponseModel>> AuthenticateAdmin(string email);
        Task<ContextResponse> ValidateMobileNumber(string mobileNumber);
    }
}
