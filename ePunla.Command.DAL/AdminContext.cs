using System;
using System.Data;
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

        const string SP_SAVE_CROP = "sp_saveCrop";

        private readonly IDatabaseConnection _dbConnection;

        public AdminContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<int>> SaveCrop(SaveCropDto saveCropDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@cropId", saveCropDto.CropId);
            dynamicParameters.Add("@categoryId", saveCropDto.CategoryId);
            dynamicParameters.Add("@crop", saveCropDto.Crop);
            dynamicParameters.Add("@duration", saveCropDto.Duration);
            dynamicParameters.AddValidationParam();

            var result = await dbConn.QueryFirstOrDefaultAsync<int>(SP_SAVE_CROP, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, result);
        }

        public async Task<ContextResponse> ValidateClaim(int ClaimId, ValidateClaimDto validateClaimDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@claimId", ClaimId);
            dynamicParameters.Add("@isApproved", validateClaimDto.IsApproved);
            dynamicParameters.Add("@remarks", validateClaimDto.Remarks);
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
