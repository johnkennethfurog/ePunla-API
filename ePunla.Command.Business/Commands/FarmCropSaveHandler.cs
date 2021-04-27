using System;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.Interfaces;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class FarmCropSaveHandler : IRequestHandler<FarmCropSaveCommand, MediatrResponse<int>>
    {
        private readonly IFarmerContext _farmerContext;

        public FarmCropSaveHandler(IFarmerContext farmerContext)
        {
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse<int>> Handle(FarmCropSaveCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _farmerContext.SaveCrop(request.FarmerId, request.FarmCropSaveDto);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.CropStatusIsNotPlanted:
                        return new MediatrResponse<int>(new ErrorMessage("Cannot update crop, status of crop is not planted"));
                    case ErrorCode.FarmCropNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Crop does not exist"));
                    case ErrorCode.FarmNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Farm does not exist"));
                    case ErrorCode.CropNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Crop does not exist"));
                    case ErrorCode.CropIsAlreadyPlanted:
                        return new MediatrResponse<int>(new ErrorMessage("Crop is already planted to that farm"));
                }
            }

            return new MediatrResponse<int>(contextResponse.Value);
        }
    }
}
