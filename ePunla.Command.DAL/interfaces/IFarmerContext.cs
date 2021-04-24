using System;
using System.Threading.Tasks;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL.Interfaces
{
    public interface IFarmerContext
    {
        Task<ContextResponse<int>> SaveFarmer(RegisterFarmerDto registerFarmerDto);
    }
}
