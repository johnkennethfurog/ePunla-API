using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utillities.Dtos;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class SigninFarmerQuery : IRequest<MediatrResponse<FarmerResponseDto>>
    {
        public SigninFarmerDto SigninFarmerDto { get; set; }
    }
}
