using System.Collections.Generic;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Models;

namespace ePunla.Query.DAL.Interfaces
{
    public interface IMasterListContext
    {
        Task<ContextResponse<IEnumerable<BarangayAndAreaModel>>> GetBarangaysAndArea();
        Task<ContextResponse<IEnumerable<CategoryModel>>> GetCategories();
        Task<ContextResponse<IEnumerable<CropModel>>> GetCrops();
    }
}
