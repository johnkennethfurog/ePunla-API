using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetClaimsQuery : IRequest<MediatrResponse<IEnumerable<ClaimDto>>>
    {
        public PageRequestDto<SearchAdminClaimFieldsDto> SearchRequest { get; set; }
    }
}
