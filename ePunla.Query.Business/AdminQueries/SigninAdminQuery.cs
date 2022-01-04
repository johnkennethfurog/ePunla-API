using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utillities.Dtos;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class SigninAdminQuery : IRequest<MediatrResponse<FarmerResponseDto>>
    {
        public SigninAdminDto SigninAdminDto { get; set; }
    }
}
