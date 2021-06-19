using System.Threading.Tasks;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL.interfaces
{
    public interface IAdminContext
    {
        Task<ContextResponse> ValidateFarm(int FarmId, ValidateFarmDto validateFarmDto);
        Task<ContextResponse> ValidateClaim(int ClaimId, ValidateClaimDto validateClaimDto);
    }
}
