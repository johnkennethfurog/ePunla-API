using System;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.interfaces;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class SetClaimAsClaimedHandler : IRequestHandler<SetClaimAsClaimedCommand, MediatrResponse>
    {
        private readonly IAdminContext _adminContext;

        public SetClaimAsClaimedHandler(IAdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public async Task<MediatrResponse> Handle(SetClaimAsClaimedCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _adminContext.SetClaimAsClaimed(request.ClaimId);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.ClaimNotFound:
                        return new MediatrResponse(new ErrorMessage("Claim does not exist"));
                    case ErrorCode.ClaimAlreadyClaimed:
                        return new MediatrResponse(new ErrorMessage("Cannot validate claim, claim is already claimed"));
                    case ErrorCode.ClaimAlreadyDenied:
                        return new MediatrResponse(new ErrorMessage("Cannot validate claim, claim is already denied"));
                    case ErrorCode.ClaimAlreadyForVerification:
                        return new MediatrResponse(new ErrorMessage("Cannot validate claim, claim is already for verification"));
                    case ErrorCode.ClaimStatusIsApproved:
                        return new MediatrResponse(new ErrorMessage("Cannot validate claim, claim is already approved"));
                }
            }

            return new MediatrResponse();
        }
    }
}
