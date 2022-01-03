using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmerDashboardQuery : IRequest<MediatrResponse<FarmerDashboardDto>> { }
}
