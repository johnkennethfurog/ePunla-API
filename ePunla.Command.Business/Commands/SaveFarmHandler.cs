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
    public class SaveFarmHandler : IRequestHandler<SaveFarmCommand, MediatrResponse<int>>
    {
        private readonly IFarmerContext _farmerContext;

        public SaveFarmHandler(IFarmerContext farmerContext)
        {
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse<int>> Handle(SaveFarmCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _farmerContext.SaveFarm(request.FarmerId, request.FarmSaveDto);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.FarmNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Farm does not exist"));
                    case ErrorCode.FarmStatusIsNotPending:
                        return new MediatrResponse<int>(new ErrorMessage("Unable to update farm, status is not pending"));
                    case ErrorCode.BarangayNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Barangay not found"));
                    case ErrorCode.BarangayAreaNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Barangay Area not found"));
                }
            }

            return new MediatrResponse<int>(contextResponse.Value);
        }
    }
}
