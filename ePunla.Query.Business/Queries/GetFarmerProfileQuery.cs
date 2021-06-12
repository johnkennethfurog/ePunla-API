using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmerProfileQuery : IRequest<MediatrResponse<FarmerProfileDto>>
    {
        public int FarmerId { get; set; }
    }
}
