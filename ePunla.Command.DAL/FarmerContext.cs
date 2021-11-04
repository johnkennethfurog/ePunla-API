using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ePunla.Command.DAL.Interfaces;
using ePunla.Command.DAL.Models;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.DbConnect;
using ePunla.Common.Utilitites.Extensions;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL
{
    public class FarmerContext : IFarmerContext
    {
        const string SP_SAVE_FARM = "sp_saveFarm";

        const string SP_REGISTER_FARMER = "sp_registerFarmer";

        const string SP_DELETE_CROP = "sp_farmCropDelete";
        const string SP_HARVEST_CROP = "sp_farmCropHarvest";
        const string SP_SAVE_CROP = "sp_farmCropSave";

        const string SP_DELETE_CLAIM = "sp_deleteFarmerClaim";
        const string SP_SAVE_CLAIM = "sp_saveClaim";

        private readonly IDatabaseConnection _dbConnection;

        public FarmerContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<int>> SaveFarmer(RegisterFarmerDto registerFarmerDto, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FirstName", registerFarmerDto.FirstName);
            dynamicParameters.Add("@LastName", registerFarmerDto.LastName);
            dynamicParameters.Add("@MiddleName", registerFarmerDto.MiddleName);
            dynamicParameters.Add("@StreetAddress", registerFarmerDto.StreetAddress);
            dynamicParameters.Add("@BarangayId", registerFarmerDto.BarangayId);
            dynamicParameters.Add("@BarangayAreaId", registerFarmerDto.BarangayAreaId);
            dynamicParameters.Add("@MobileNumber", registerFarmerDto.MobileNumber);
            dynamicParameters.Add("@PasswordHash", PasswordHash);
            dynamicParameters.Add("@PasswordSalt", PasswordSalt);
            dynamicParameters.Add("@Avatar", registerFarmerDto.Avatar);
            dynamicParameters.Add("@AvatarId", registerFarmerDto.AvatarId);
            dynamicParameters.Add("@MobileNumber", registerFarmerDto.MobileNumber);
            dynamicParameters.Add("@IdentityDocumentId", registerFarmerDto.IdentityDocumentId);
            dynamicParameters.Add("@IdentityDocumentUrl", registerFarmerDto.IdentityDocumentUrl);
            dynamicParameters.AddValidationParam();

            var result = (await dbConn.QueryAsync<int>(SP_REGISTER_FARMER, dynamicParameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, result);
        }

        public async Task<ContextResponse> DeleteCrop(int FarmCropId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmCropId", FarmCropId);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_DELETE_CROP, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse> HarvestCrop(int FarmCropId, DateTime HarvestDate)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmCropId", FarmCropId);
            dynamicParameters.Add("@HarvestDate", HarvestDate);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_HARVEST_CROP, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse<int>> SaveCrop(int FarmerId, FarmCropSaveDto FarmCropSaveDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@farmerId", FarmerId);
            dynamicParameters.Add("@farmCropId", FarmCropSaveDto.FarmCropId);
            dynamicParameters.Add("@farmId", FarmCropSaveDto.FarmId);
            dynamicParameters.Add("@cropId", FarmCropSaveDto.CropId);
            dynamicParameters.Add("@datePlanted", FarmCropSaveDto.DatePlanted);
            dynamicParameters.Add("@areaSize", FarmCropSaveDto.AreaSize);
            dynamicParameters.AddValidationParam();

            var result = (await dbConn.QueryAsync<int>(SP_SAVE_CROP, dynamicParameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, result);
        }

        public async Task<ContextResponse<int>> SaveFarm(int FarmerId, FarmSaveDto FarmSaveDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmerId", FarmerId);
            dynamicParameters.Add("@FarmId", FarmSaveDto.FarmId);
            dynamicParameters.Add("@AreaSize", FarmSaveDto.Size);
            dynamicParameters.Add("@Name", FarmSaveDto.Name);
            dynamicParameters.Add("@StreetAddress", FarmSaveDto.StreetAddress);
            dynamicParameters.Add("@BarangayId", FarmSaveDto.BarangayId);
            dynamicParameters.Add("@BarangayAreaId", FarmSaveDto.BarangayAreaId);
            dynamicParameters.Add("@Lng", FarmSaveDto.Lng);
            dynamicParameters.Add("@Lat", FarmSaveDto.Lat);
            dynamicParameters.AddValidationParam();

            var result = (await dbConn.QueryAsync<int>(SP_SAVE_FARM, dynamicParameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, result);
        }

        public async Task<ContextResponse> DeleteClaim(int ClaimId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ClaimId", ClaimId);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_DELETE_CLAIM, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse<int>> SaveClaim(SaveClaimDto saveClaimDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var claimCausesModel = saveClaimDto.ClaimCauses
                                    .Select(x => new DamageCauseModel { DamagedAreaSize = x.DamagedAreaSize, DamageTypeId = (int) x.DamageTypeId });

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ClaimId", saveClaimDto.ClaimId);
            dynamicParameters.Add("@FarmCropId", saveClaimDto.FarmCropId);
            dynamicParameters.Add("@Description", saveClaimDto.Description);
            dynamicParameters.Add("@PhotoUrl", saveClaimDto.PhotoUrl);
            dynamicParameters.Add("@PhotoId", saveClaimDto.PhotoId);
            dynamicParameters.Add("@DamagedArea", saveClaimDto.DamagedArea);
            dynamicParameters.Add("@ClaimCauses", claimCausesModel.ToList().ToDataTable().AsTableValuedParameter());
            dynamicParameters.AddValidationParam();

            var result = (await dbConn.QueryAsync<int>(SP_SAVE_CLAIM, dynamicParameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, result);
        }
    }
}
