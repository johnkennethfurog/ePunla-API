using System;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.interfaces;
using ePunla.Command.Domain.Dtos;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class SaveBarangayHandler : IRequestHandler<SaveBarangayCommand, MediatrResponse<int>>
    {
        private readonly IMasterListContext _masterListContext;

        public SaveBarangayHandler(IMasterListContext masterListContext)
        {
            _masterListContext = masterListContext;
        }

        public async Task<MediatrResponse<int>> Handle(SaveBarangayCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _masterListContext.SaveBarangay(request.SaveBarangayDto);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.BarangayAlreadyExist:
                        return new MediatrResponse<int>(new ErrorMessage("Barangay does not exist"));
                    case ErrorCode.BarangayNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Barangay already exist"));
                }
            }

            return new MediatrResponse<int>(contextResponse.Value);
        }
    }
}
