using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Models;

namespace ePunla.Query.DAL.Interfaces
{
    public interface IFarmerContext
    {
        Task<ContextResponse<IEnumerable<FarmModel>>> GetFarms(int FarmerId);
        Task<ContextResponse<IEnumerable<FarmCropModel>>> GetCrops(int FarmerId);
    }
}
