using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ePunla.Command.DAL.Interfaces;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.DbConnect;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL
{
    public class FarmerContext : IFarmerContext
    {
        const string SP_SAVE_FARMER = "sp_saveFarmer";

        private readonly IDatabaseConnection _dbConnection;

        public FarmerContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<int>> SaveFarmer(RegisterFarmerDto registerFarmerDto)
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
            dynamicParameters.Add("@Password", registerFarmerDto.Password);
            dynamicParameters.Add("@Avatar", registerFarmerDto.Avatar);
            dynamicParameters.Add("@AvatarId", registerFarmerDto.AvatarId);
            dynamicParameters.Add("@MobileNumber", registerFarmerDto.MobileNumber);
            dynamicParameters.Add("@Validation", null, DbType.Int32, direction: ParameterDirection.Output);

            var response = (await dbConn.QueryAsync<int>(SP_SAVE_FARMER, dynamicParameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();

            var validation = dynamicParameters.Get<int?>("@Validation");
            if (validation != null)
                return new ContextResponse<int>(validation);
            else
                return new ContextResponse<int>(response);
        }
    }
}
