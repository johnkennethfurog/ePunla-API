using System;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class SetClaimForVerificationCommand: IRequest<MediatrResponse>
    {
        public int ClaimId { get; set; }
    }
}
