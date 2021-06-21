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
    public class ChangeBarangayStatHandler : IRequestHandler<ChangeBarangayStatCommand, MediatrResponse>
    {

        private readonly IMasterListContext _masterListContext;

        public ChangeBarangayStatHandler(IMasterListContext masterListContext)
        {
            _masterListContext = masterListContext;
        }


        public async Task<MediatrResponse> Handle(ChangeBarangayStatCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _masterListContext.ChangeBarangayStatus(request.BarangayId,request.ChangeBarangayStatDto.IsActive);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.BarangayNotFound:
                        return new MediatrResponse(new ErrorMessage("Barangay does not exist"));
                }
            }

            return new MediatrResponse();
        }
    }
}
