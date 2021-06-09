using System;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Enums;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class ValidateFarmerMobileNumberHandler : IRequestHandler<ValidateFarmerMobileNumberQuery, MediatrResponse>
    {
        private readonly IAuthenticationContext _authenticationContext;

        public ValidateFarmerMobileNumberHandler(IAuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public async Task<MediatrResponse> Handle(ValidateFarmerMobileNumberQuery request, CancellationToken cancellationToken)
        {
            var contextResponse = await _authenticationContext.ValidateMobileNumber(request.MobileNumber);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.MobileNumberAlreadyExist:
                        return new MediatrResponse(new ErrorMessage("Mobile number already in use."));
                }
            }

            return new MediatrResponse();
        }
    }
}
