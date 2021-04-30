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
    public class DeleteClaimHandler : IRequestHandler<DeleteClaimCommand, MediatrResponse>
    {
        private readonly IFarmerContext _farmerContext;

        public DeleteClaimHandler(IFarmerContext farmerContext)
        {
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse> Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _farmerContext.DeleteClaim(request.ClaimId);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.ClaimStatusIsNotPending:
                        return new MediatrResponse(new ErrorMessage("Cannot delete claim, status of claim is not pending"));
                    case ErrorCode.ClaimNotFound:
                        return new MediatrResponse(new ErrorMessage("Claim does not exist"));
                }
            }

            return new MediatrResponse();
        }
    }
}
