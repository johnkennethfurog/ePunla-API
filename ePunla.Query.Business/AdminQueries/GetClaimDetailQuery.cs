using System;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetClaimDetailQuery : IRequest<MediatrResponse<ClaimDetailDto>>
    {
        public int ClaimId { get; set; }
    }
}
