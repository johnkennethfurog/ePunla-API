using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.DAL.Interfaces
{
    public interface IAdminContext
    {
        Task<ContextResponse<IEnumerable<FarmModel>>> GetFarms(PageRequestDto<SearchFarmFieldsDto> FarmsLookupFields);
        Task<ContextResponse<IEnumerable<ClaimModel>>> GetClaims(PageRequestDto<SearchAdminClaimFieldsDto> ClaimsLookupFields);
        Task<ContextResponse<ClaimDetailModel>> GetClaimDetail(int claimId);
        Task<ContextResponse<StatDashboardModel>> GetStatistic();
        Task<ContextResponse<IEnumerable<CropsOccuranceModel>>> GetCropsOccurance(SearchCropsOccuranceDto CropsOccuranceLookupFields);
        Task<ContextResponse<AdminProfileModel>> GetAdminProfile(int userId);
    }
}
