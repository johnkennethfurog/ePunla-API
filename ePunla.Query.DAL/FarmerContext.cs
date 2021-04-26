using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using ePunla.Common.Utilitites.DbConnect;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.DAL
{
    public class FarmerContext : IFarmerContext
    {
        const string SP_GET_FARMS = "sp_getFarmerFarms";
        const string SP_GET_CROPS = "sp_getFarmersCrops";

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

        public async Task<ContextResponse<IEnumerable<FarmModel>>> GetFarms(int FarmerId)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FarmerId", FarmerId);

            var response = (await dbConn.QueryAsync<FarmModel>(SP_GET_FARMS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<FarmModel>>(response);

        }
    }
}
