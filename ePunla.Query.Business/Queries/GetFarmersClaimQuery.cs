using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmersClaimQuery : IRequest<MediatrResponse<IEnumerable<FarmerClaimDto>>>
    {
        public int FarmerId { get; set; }
        public SearchClaimFieldsDto SearchField { get; set; }
    }
}
