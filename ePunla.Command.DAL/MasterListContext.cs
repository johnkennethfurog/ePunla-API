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
    public class MasterListContext : IMasterListContext
    {
        const string SP_SAVE_CROP = "sp_saveCrop";
        const string SP_SAVE_BARANGAY = "sp_saveBarangay";
        const string SP_UPDATE_BARANGAY_STAT = "sp_updateBarangayStatus";

        private readonly IDatabaseConnection _dbConnection;

        public MasterListContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public async Task<ContextResponse> ChangeBarangayStatus(int barangayId, bool isActive)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@barangayId", barangayId);
            dynamicParameters.Add("@isActive", isActive);
            dynamicParameters.AddValidationParam();

            await dbConn.QueryAsync(SP_UPDATE_BARANGAY_STAT, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse.ValidateContextResponse(validation);
        }

        public async Task<ContextResponse<int>> SaveBarangay(SaveBarangayDto saveBarangayDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@barangayId", saveBarangayDto.BarangayId);
            dynamicParameters.Add("@barangayName", saveBarangayDto.BarangayName);
            dynamicParameters.Add("@areas", saveBarangayDto.Areas.ToList().ToDataTable().AsTableValuedParameter());
            dynamicParameters.AddValidationParam();

            var result = await dbConn.QueryFirstOrDefaultAsync<int>(SP_SAVE_BARANGAY, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, result);
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
    }
}
