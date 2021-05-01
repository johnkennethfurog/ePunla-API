using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.Interfaces;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Helpers;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class RegisterFarmerHandler : IRequestHandler<RegisterFarmerCommand, MediatrResponse<int>>
    {
        private readonly IFarmerContext _farmerContext;

        public RegisterFarmerHandler(IFarmerContext farmerContext)
        {
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse<int>> Handle(RegisterFarmerCommand request, CancellationToken cancellationToken)
        {
            UserHelper.CreatePasswordHash(request.RegisterFarmerDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            var contextResponse = await _farmerContext.SaveFarmer(request.RegisterFarmerDto, PasswordHash, PasswordSalt);

            if(!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.BarangayNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Barangay not found"));
                    case ErrorCode.BarangayAreaNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Barangay Area not found"));
                    case ErrorCode.MobileNumberAlreadyExist:
                        return new MediatrResponse<int>(new ErrorMessage("Mobile Number already exist"));
                }
            }

            return new MediatrResponse<int>(contextResponse.Value);
        }
    }
}
