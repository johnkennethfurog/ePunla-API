using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class SigninFarmerQuery : IRequest<MediatrResponse<SigninFarmerResponseDto>>
    {
        public SigninFarmerDto SigninFarmerDto { get; set; }
    }
}
