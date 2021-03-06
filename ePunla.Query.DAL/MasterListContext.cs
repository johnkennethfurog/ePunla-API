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
    public class MasterListContext : IMasterListContext
    {
        const string SP_GET_BARANGAYS_AND_AREAS = "sp_getBarangaysAndAreas";
        const string SP_GET_CATEGORIES = "sp_getCategories";
        const string SP_GET_CROPS = "sp_getCrops";

        private readonly IDatabaseConnection _dbConnection;

        public MasterListContext(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContextResponse<IEnumerable<BarangayAndAreaModel>>> GetBarangaysAndArea()
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var response = (await dbConn.QueryAsync<BarangayAndAreaModel>(SP_GET_BARANGAYS_AND_AREAS, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<BarangayAndAreaModel>>(response);
        }

        public async Task<ContextResponse<IEnumerable<CategoryModel>>> GetCategories()
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();
            var response = (await dbConn.QueryAsync<CategoryModel>(SP_GET_CATEGORIES, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<CategoryModel>>(response);
        }

        public async Task<ContextResponse<IEnumerable<CropModel>>> GetCrops(PageRequestDto<SearchAdminCropFieldsDto> searchRequest)
        {
            using var dbConn = await _dbConnection.CreateConnectionAsync();

            var searchField = searchRequest.SearchField;
            var page = searchRequest.Page;

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@searchText", searchField.SearchText);
            dynamicParameters.Add("@categoryId", searchField.CategoryId);
            dynamicParameters.Add("@showInactive", searchField.ShowInactive);
            dynamicParameters.Add("@pageNUmber", page.PageNumber);
            dynamicParameters.Add("@pageSize", page.PageSize);

            var response = (await dbConn.QueryAsync<CropModel>(SP_GET_CROPS, dynamicParameters, commandType: CommandType.StoredProcedure));
            return new ContextResponse<IEnumerable<CropModel>>(response);
        }
    }
}
