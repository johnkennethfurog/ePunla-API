using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.Interfaces;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Helpers;
using ePunla.Common.Utilitites.Interfaces;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using ePunla.Common.Utillities.Dtos;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class RegisterFarmerHandler : IRequestHandler<RegisterFarmerCommand, MediatrResponse<FarmerResponseDto>>
    {
        private readonly IFarmerContext _farmerContext;
        private readonly ITokenService _tokenService;

        public RegisterFarmerHandler(IFarmerContext farmerContext, ITokenService tokenService)
        {
            _farmerContext = farmerContext;
            _tokenService = tokenService;
        }

        public async Task<MediatrResponse<FarmerResponseDto>> Handle(RegisterFarmerCommand request, CancellationToken cancellationToken)
        {
            var farmer = request.RegisterFarmerDto;
            UserHelper.CreatePasswordHash(farmer.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            var contextResponse = await _farmerContext.SaveFarmer(farmer, PasswordHash, PasswordSalt);

            if(!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.BarangayNotFound:
                        return new MediatrResponse<FarmerResponseDto>(new ErrorMessage("Barangay not found"));
                    case ErrorCode.BarangayAreaNotFound:
                        return new MediatrResponse<FarmerResponseDto>(new ErrorMessage("Barangay Area not found"));
                    case ErrorCode.MobileNumberAlreadyExist:
                        return new MediatrResponse<FarmerResponseDto>(new ErrorMessage("Mobile Number already exist"));
                }
            }

            var farmerId = contextResponse.Value;
            var token = _tokenService.CreateToken(farmerId.ToString());
            var farmerInfo = new FarmerInfoDto { Avatar = farmer.Avatar, FirstName= farmer.FirstName, LastName = farmer.LastName, Status = "Pending" };

            var farmerResponse = new FarmerResponseDto { User = farmerInfo, Token = token };

            return new MediatrResponse<FarmerResponseDto>(farmerResponse);
        }
    }
}
