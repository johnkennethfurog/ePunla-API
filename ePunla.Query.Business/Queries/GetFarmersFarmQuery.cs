using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmersFarmQuery : IRequest<MediatrResponse<IEnumerable<FarmerFarmDto>>>
    {
        public int FarmerId { get; set; }
        public string Status { get; set; }
    }
}
