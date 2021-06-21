using System;
using System.Threading.Tasks;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;

namespace ePunla.Command.DAL.interfaces
{
    public interface IMasterListContext
    {
        Task<ContextResponse<int>> SaveCrop(SaveCropDto saveCropDto);
        Task<ContextResponse<int>> SaveBarangay(SaveBarangayDto saveBarangayDto);
        Task<ContextResponse> ChangeBarangayStatus(int barangayId, bool isActive);
    }
}
