using System.Data;
using Dapper;

namespace ePunla.Common.Utilitites.Extensions
{
    public static class DynamicParameterExtension
    {
        public static void AddValidationParam(this DynamicParameters dynamicParameters)
        {
            dynamicParameters.Add("@Validation", null, DbType.Int32, direction: ParameterDirection.Output);
        }

        public static int? GetValidationParamValue(this DynamicParameters dynamicParameters)
        {
            return dynamicParameters.Get<int?>("@Validation");
        }
    }
}
