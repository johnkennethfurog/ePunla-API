using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ePunla.Common.Utilitites.DbConnect;
using ePunla.Common.Utilitites.Extensions;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.DAL.Models;

namespace ePunla.Query.DAL
{
    public class AuthenticationContext : IAuthenticationContext
    {
        const string SP_AUTHENTICATE_FARMER = "sp_authenticateFarmer";
        const string SP_AUTHENTICATE_ADMIN = "sp_authenticateAdmin";
        const string SP_VALIDATE_MOBILE_NUMBER = "sp_checkFarmerMobileNumber";
        private readonly IDatabaseConnection _dbConnection;

        public AuthenticationContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<AdminAuthResponseModel>> AuthenticateAdmin(string email)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();


            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@email", email);
            dynamicParameters.AddValidationParam();

            var response = await dbConn.QueryFirstOrDefaultAsync<AdminAuthResponseModel>(SP_AUTHENTICATE_ADMIN, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<AdminAuthResponseModel>.ValidateContextResponse(validation, response);
        }

        public async Task<ContextResponse<FarmerAuthResponseModel>> AuthenticateFarmer(string mobileNumber)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();


            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@mobileNumber", mobileNumber);
            dynamicParameters.AddValidationParam();

            var response = await dbConn.QueryFirstOrDefaultAsync<FarmerAuthResponseModel>(SP_AUTHENTICATE_FARMER, dynamicParameters, commandType: CommandType.StoredProcedure);

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<FarmerAuthResponseModel>.ValidateContextResponse(validation, response);
        }

        public async Task<ContextResponse> ValidateMobileNumber(string mobileNumber)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();


            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@mobileNumber", mobileNumber);
            dynamicParameters.AddValidationParam();

            var response = (await dbConn.QueryAsync<int>(SP_VALIDATE_MOBILE_NUMBER, dynamicParameters, commandType: CommandType.StoredProcedure))?.FirstOrDefault();

            var validation = dynamicParameters.GetValidationParamValue();
            return ContextResponse<int>.ValidateContextResponse(validation, response);
        }
    }
}
