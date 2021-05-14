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
    public class CropsContext : ICropsContext
    {
        const string SP_CROPS_LOOKUP = "sp_CropsLookup";

        private readonly IDatabaseConnection _dbConnection;

        public CropsContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<IEnumerable<LookupModel>>> CropsLookup(CropsLookupFieldsDto lookupFieldsDto)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@cropName", lookupFieldsDto.Keyword);
            dynamicParameters.Add("@pageNUmber", lookupFieldsDto.Page.PageNumber);
            dynamicParameters.Add("@pageSize", lookupFieldsDto.Page.PageSize);

            var response = (await dbConn.QueryAsync<LookupModel>(SP_CROPS_LOOKUP, dynamicParameters, commandType: CommandType.StoredProcedure));

            return new ContextResponse<IEnumerable<LookupModel>>(response);
        }
    }
}
