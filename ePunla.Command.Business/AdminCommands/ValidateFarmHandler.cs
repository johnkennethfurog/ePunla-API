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
    public class ValidateFarmHandler : IRequestHandler<ValidateFarmCommand, MediatrResponse>
    {
        private readonly IAdminContext _adminContext;

        public ValidateFarmHandler(IAdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public async Task<MediatrResponse> Handle(ValidateFarmCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _adminContext.ValidateFarm(request.FarmId, request.ValidateFarmDto);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.FarmNotFound:
                        return new MediatrResponse(new ErrorMessage("Farm does not exist"));
                    case ErrorCode.FarmStatusIsNotPending:
                        return new MediatrResponse(new ErrorMessage("Unable to validate farm, status is not pending"));
                }
            }

            return new MediatrResponse();
        }
    }
}
