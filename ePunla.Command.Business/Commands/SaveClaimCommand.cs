using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class SaveClaimCommand : IRequest<MediatrResponse<int>>
    {
        public SaveClaimDto SaveClaimDto { get; set; }
    }
}
