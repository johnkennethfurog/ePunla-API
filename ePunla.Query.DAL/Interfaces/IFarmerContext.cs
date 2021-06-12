using System.Collections.Generic;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.DAL.Interfaces
{
    public interface IFarmerContext
    {
        Task<ContextResponse<FarmerModel>> GetProfile(int farmerId);

        Task<ContextResponse<IEnumerable<FarmModel>>> GetFarms(int FarmerId, string Status);
        Task<ContextResponse<IEnumerable<FarmCropModel>>> GetCrops(int FarmerId, SearchCropFieldsDto SearchFields);

        Task<ContextResponse<IEnumerable<FarmerClaimModel>>> GetClaims(int FarmerId, SearchClaimFieldsDto SearchFields);
        Task<ContextResponse<IEnumerable<ClaimDamageCauseModel>>> GetDamageCause(IEnumerable<int> claimIds);
    }
}
