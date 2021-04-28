using System;
using System.Threading.Tasks;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL.Interfaces
{
    public interface IFarmerContext
    {
        Task<ContextResponse<int>> SaveFarmer(RegisterFarmerDto registerFarmerDto, byte[] PasswordHash, byte[] PasswordSalt);
        Task<ContextResponse> DeleteCrop(int FarmCropId);
        Task<ContextResponse> HarvestCrop(int FarmCropId, DateTime HarvestDate);
        Task<ContextResponse<int>> SaveCrop(int FarmerId, FarmCropSaveDto FarmCropSaveDto);
        Task<ContextResponse<int>> SaveFarm(int FarmerId, FarmSaveDto FarmSaveDto);
    }
}
