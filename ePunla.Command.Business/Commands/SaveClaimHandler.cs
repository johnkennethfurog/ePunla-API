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
    public class SaveClaimHandler : IRequestHandler<SaveClaimCommand, MediatrResponse<int>>
    {
        private readonly IFarmerContext _farmerContext;

        public SaveClaimHandler(IFarmerContext farmerContext)
        {
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse<int>> Handle(SaveClaimCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _farmerContext.SaveClaim(request.SaveClaimDto);


            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.ClaimNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Claim does not exist"));
                    case ErrorCode.ClaimStatusIsNotPending:
                        return new MediatrResponse<int>(new ErrorMessage("Cannot delete claim, status of claim is not pending"));
                    case ErrorCode.ClaimDuplicateDamageType:
                        return new MediatrResponse<int>(new ErrorMessage("Cause of damage is duplicated"));
                    case ErrorCode.CropStatusIsNotPlanted:
                        return new MediatrResponse<int>(new ErrorMessage("Crop status is not planted"));
                    case ErrorCode.FarmCropNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Crop does not exist"));
                }
            }

            return new MediatrResponse<int>(contextResponse.Value);
        }
    }
}
