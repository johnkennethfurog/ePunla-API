using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetCropsOccuranceQuery : IRequest<MediatrResponse<IEnumerable<CropsOccuranceDto>>>
    {
        public SearchCropsOccuranceDto CropsOccuranceLookupFields { get; set; }
    }
}
