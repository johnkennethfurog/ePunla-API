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
    public class ValidateClaimHandler : IRequestHandler<ValidateClaimCommand, MediatrResponse>
    {
        private readonly IAdminContext _adminContext;

        public ValidateClaimHandler(IAdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public async Task<MediatrResponse> Handle(ValidateClaimCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _adminContext.ValidateClaim(request.ClaimId, request.ValidateClaimDto);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.ClaimNotFound:
                        return new MediatrResponse(new ErrorMessage("Claim does not exist"));
                    case ErrorCode.ClaimStatusIsNotPending:
                        return new MediatrResponse(new ErrorMessage("Cannot validate claim, status of claim is not pending"));
                }
            }

            return new MediatrResponse();
        }
    }
}
