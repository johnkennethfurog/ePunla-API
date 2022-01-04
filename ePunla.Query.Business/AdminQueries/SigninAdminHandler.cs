using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Helpers;
using ePunla.Common.Utilitites.Interfaces;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using ePunla.Common.Utillities.Dtos;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Enums;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class SigninAdminHandler : IRequestHandler<SigninAdminQuery, MediatrResponse<FarmerResponseDto>>
    {
        private readonly IAuthenticationContext _authenticationContext;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public SigninAdminHandler(IAuthenticationContext authenticationContext, IMapper mapper, ITokenService tokenService)
        {
            _authenticationContext = authenticationContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<MediatrResponse<FarmerResponseDto>> Handle(SigninAdminQuery request, CancellationToken cancellationToken)
        {
            var signinDto = request.SigninAdminDto;
            var contextResponse = await _authenticationContext.AuthenticateAdmin(signinDto.Email);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.InvalidCredential:
                        return new MediatrResponse<FarmerResponseDto>(new ErrorMessage("Invalid signin credential"));
                }
            }

            var AdminModel = contextResponse.Value;
            var isPasswordValid = UserHelper.VerifyPassword(signinDto.Password, AdminModel.PasswordHash, AdminModel.PasswordSalt);

            if(!isPasswordValid)
                return new MediatrResponse<FarmerResponseDto>(new ErrorMessage("Invalid signin credential"));

            var token = _tokenService.CreateToken(AdminModel.UserId.ToString());

            var signinResponse = new FarmerResponseDto { Token = token };

            return new MediatrResponse<FarmerResponseDto>(signinResponse);
        }
    }
}
