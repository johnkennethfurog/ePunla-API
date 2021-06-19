using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class ValidateFarmCommand : IRequest<MediatrResponse>
    {
        public int FarmId { get; set; }
        public ValidateFarmDto ValidateFarmDto { get; set; }
    }
}
