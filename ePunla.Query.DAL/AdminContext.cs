using System;
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
    public class AdminContext : IAdminContext
    {
        const string SP_GET_FARMS = "sp_getListOfFarms";

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
    }
}
