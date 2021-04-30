using System;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class DeleteClaimCommand : IRequest<MediatrResponse>
    {
        public int ClaimId { get; set; }
    }
}
