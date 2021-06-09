using System;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class ValidateFarmerMobileNumberQuery : IRequest<MediatrResponse>
    {
        public string MobileNumber { get; set; }
    }
}
