using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class ValidateClaimCommand : IRequest<MediatrResponse>
    {
        public int ClaimId { get; set; }
        public ValidateClaimDto ValidateClaimDto { get; set; }
    }
}
