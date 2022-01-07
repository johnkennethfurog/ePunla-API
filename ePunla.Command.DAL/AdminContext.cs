using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ePunla.Command.DAL.interfaces;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.DbConnect;
using ePunla.Common.Utilitites.Extensions;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL
{
    public class AdminContext : IAdminContext
    {
        const string SP_VALIDATE_FARM = "sp_validateFarm";
        const string SP_VALIDATE_CLAIM = "sp_validateClaim";
        const string SP_SET_CLAIM_FOR_VERIFICATION = "sp_setClaimForVerification";
        const string SP_SET_CLAIM_AS_CLAIMED = "sp_setClaimAsClaimed";

        private readonly IDatabaseConnection _dbConnection;

        public AdminContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse> SetClaimForVerification(int ClaimId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@claimId", ClaimId);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_SET_CLAIM_FOR_VERIFICATION, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse> SetClaimAsClaimed(int ClaimId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@claimId", ClaimId);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_SET_CLAIM_AS_CLAIMED, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse> ValidateClaim(int ClaimId, string ReferenceNumber, ValidateClaimDto validateClaimDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@claimId", ClaimId);
            dynamicParameters.Add("@isApproved", validateClaimDto.IsApproved);
            dynamicParameters.Add("@remarks", validateClaimDto.Remarks);
            dynamicParameters.Add("@referenceNumber", ReferenceNumber);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_VALIDATE_CLAIM, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse> ValidateFarm(int FarmId, ValidateFarmDto validateFarmDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@farmId", FarmId);
            dynamicParameters.Add("@isApproved", validateFarmDto.IsApproved);
            dynamicParameters.Add("@remarks", validateFarmDto.Remarks);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_VALIDATE_FARM, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }
    }
}
