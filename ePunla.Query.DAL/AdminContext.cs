using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ePunla.Common.Utilitites.DbConnect;
using ePunla.Common.Utilitites.Extensions;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.DAL
{
    public class AdminContext : IAdminContext
    {
        const string SP_GET_FARMS = "sp_getListOfFarms";
        const string SP_GET_CLAIMS = "sp_getListOfClaims";
        const string SP_GET_CLAIM_DETAIL = "sp_getClaimDetail";
        const string SP_GET_ADMIN_DASHBOARD_DATA = "sp_getAdminDashboardData";

        private readonly IDatabaseConnection _dbConnection;

        public AdminContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<IEnumerable<FarmModel>>> GetFarms(PageRequestDto<SearchFarmFieldsDto> FarmsLookupFields)
        {
            var searchField = FarmsLookupFields.SearchField;
            var page = FarmsLookupFields.Page;

            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@barangayId", searchField.BarangayId);
            dynamicParameters.Add("@searchText", searchField.SearchText);
            dynamicParameters.Add("@Status", searchField.Status.ToString());

            dynamicParameters.Add("@pageNumber", page.PageNumber);
            dynamicParameters.Add("@pageSize", page.PageSize);

            var response = (await dbConn.QueryAsync<FarmModel>(SP_GET_FARMS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<FarmModel>>(response);
        }

        public async Task<ContextResponse<IEnumerable<ClaimModel>>> GetClaims(PageRequestDto<SearchAdminClaimFieldsDto> ClaimsLookupFields)
        {
            var searchField = ClaimsLookupFields.SearchField;
            var page = ClaimsLookupFields.Page;

            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@barangayId", searchField.BarangayId);
            dynamicParameters.Add("@searchText", searchField.SearchText);
            dynamicParameters.Add("@Status", searchField.Status.ToString());

            dynamicParameters.Add("@pageNumber", page.PageNumber);
            dynamicParameters.Add("@pageSize", page.PageSize);

            var response = (await dbConn.QueryAsync<ClaimModel>(SP_GET_CLAIMS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<ClaimModel>>(response);
        }

        public async Task<ContextResponse<ClaimDetailModel>> GetClaimDetail(int claimId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@claimId", claimId);
            dynamicParameters.AddValidationParam();

            var response = (await dbConn.QueryFirstOrDefaultAsync<ClaimDetailModel>(SP_GET_CLAIM_DETAIL, dynamicParameters, commandType: CommandType.StoredProcedure));

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<ClaimDetailModel>.ValidateContextResponse(validation, response);
        }

        public async Task<ContextResponse<StatDashboardModel>> GetStatistic()
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();


            var response = (await dbConn.QueryMultipleAsync(SP_GET_ADMIN_DASHBOARD_DATA, commandType: CommandType.StoredProcedure));

            var cropPerBarangay = response.Read<StatCropPerBarangayModel>();
            var cropStatusPerBarangay = response.Read<StatCropStatusPerBarangayModel>();
            var farmerPerBarangay = response.Read<StatFarmerPerBarangayModel>();
            var statCountModel = response.Read<StatCountModel>().FirstOrDefault();

            var statDashboard = new StatDashboardModel
            {
                StatCropPerBarangayModel = cropPerBarangay,
                StatFarmerPerBarangayModel = farmerPerBarangay,
                StatCropStatusPerBarangayModel = cropStatusPerBarangay,
                StatCountModel = statCountModel
            };

            return new ContextResponse<StatDashboardModel>(statDashboard);
        }
    }
}
