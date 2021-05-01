using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Helpers;
using ePunla.Common.Utilitites.Interfaces;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using ePunla.Query.Domain.Enums;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class SigninFarmerHandler : IRequestHandler<SigninFarmerQuery, MediatrResponse<SigninFarmerResponseDto>>
    {
        private readonly IAuthenticationContext _authenticationContext;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public SigninFarmerHandler(IAuthenticationContext authenticationContext, IMapper mapper, ITokenService tokenService)
        {
            _authenticationContext = authenticationContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<MediatrResponse<SigninFarmerResponseDto>> Handle(SigninFarmerQuery request, CancellationToken cancellationToken)
        {
            var signinDto = request.SigninFarmerDto;
            var contextResponse = await _authenticationContext.AuthenticateFarmer(signinDto.MobileNumber);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.InvalidCredential:
                        return new MediatrResponse<SigninFarmerResponseDto>(new ErrorMessage("Invalid signin credential"));
                }
            }

            var farmerModel = contextResponse.Value;
            var isPasswordValid = UserHelper.VerifyPassword(signinDto.Password, farmerModel.PasswordHash, farmerModel.PasswordSalt);

            if(!isPasswordValid)
                return new MediatrResponse<SigninFarmerResponseDto>(new ErrorMessage("Invalid signin credential"));

            var farmerInfo = _mapper.Map<FarmerInfoDto>(farmerModel);
            var token = _tokenService.CreateToken(farmerModel.FarmerId.ToString());

            var signinResponse = new SigninFarmerResponseDto { User = farmerInfo, Token = token };

            return new MediatrResponse<SigninFarmerResponseDto>(signinResponse);
        }
    }
}
