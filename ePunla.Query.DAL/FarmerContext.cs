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
using FleetResponse.Common.Business.Helpers;

namespace ePunla.Query.DAL
{
    public class FarmerContext : IFarmerContext
    {
        const string SP_GET_FARMER_PROFILE = "sp_getFarmerProfile";

        const string SP_GET_FARMS = "sp_getFarmerFarms";
        const string SP_GET_CROPS = "sp_getFarmersCrops";

        const string SP_GET_CLAIM_CAUSES = "sp_getClaimCauses";
        const string SP_GET_FARMER_CLAIMS = "sp_getFarmerClaims";


        private readonly IDatabaseConnection _dbConnection;

        public FarmerContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<IEnumerable<FarmCropModel>>> GetCrops(int FarmerId, SearchCropFieldsDto SearchFields)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmerId", FarmerId);
            dynamicParameters.Add("@Status", SearchFields.Status?.ToString());
            dynamicParameters.Add("@CropId", SearchFields.CropId);
            dynamicParameters.Add("@PlantedFrom", SearchFields.PlantedFrom);
            dynamicParameters.Add("@PlantedTo", SearchFields.PlantedTo);

            var response = (await dbConn.QueryAsync<FarmCropModel>(SP_GET_CROPS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<FarmCropModel>>(response);
        }

        public async Task<ContextResponse<IEnumerable<FarmModel>>> GetFarms(int FarmerId, string Status)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmerId", FarmerId);
            dynamicParameters.Add("@Status", Status);

            var response = (await dbConn.QueryAsync<FarmModel>(SP_GET_FARMS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<FarmModel>>(response);

        }

        public async Task<ContextResponse<IEnumerable<FarmerClaimModel>>> GetClaims(int FarmerId, SearchClaimFieldsDto SearchFields)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmerId", FarmerId);
            dynamicParameters.Add("@Status", SearchFields?.Status?.ToString());

            var response = (await dbConn.QueryAsync<FarmerClaimModel>(SP_GET_FARMER_CLAIMS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<FarmerClaimModel>>(response);
        }

        public async Task<ContextResponse<IEnumerable<ClaimDamageCauseModel>>> GetDamageCause(IEnumerable<int> claimIds)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var claims = claimIds.Select(x => new ClaimIdModel { ClaimId = x });

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@claimsId", claims.ToList().ToDataTable().AsTableValuedParameter());

            var response = (await dbConn.QueryAsync<ClaimDamageCauseModel>(SP_GET_CLAIM_CAUSES, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<ClaimDamageCauseModel>>(response);
        }

        public async Task<ContextResponse<FarmerModel>> GetProfile(int farmerId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmerId", farmerId);
            dynamicParameters.AddValidationParam();

            var response = await dbConn.QueryFirstOrDefaultAsync<FarmerModel>(SP_GET_FARMER_PROFILE, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<FarmerModel>.ValidateContextResponse(validation, response);
        }
    }
}
