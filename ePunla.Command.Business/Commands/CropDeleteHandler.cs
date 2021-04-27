using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.Interfaces;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class CropDeleteHandler : IRequestHandler<CropDeleteCommand, MediatrResponse>
    {
        private readonly IFarmerContext _farmerContext;

        public CropDeleteHandler(IFarmerContext farmerContext)
        {
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse> Handle(CropDeleteCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _farmerContext.DeleteCrop(request.FarmCropId);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.CropStatusIsNotPlanted:
                        return new MediatrResponse(new ErrorMessage("Cannot delete crop, status of crop is not planted"));
                    case ErrorCode.FarmCropNotFound:
                        return new MediatrResponse(new ErrorMessage("Crop does not exist"));
                }
            }

            return new MediatrResponse();
        }
    }
}
