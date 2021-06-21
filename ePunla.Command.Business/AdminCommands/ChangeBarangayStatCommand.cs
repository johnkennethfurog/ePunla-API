using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class ChangeBarangayStatCommand : IRequest<MediatrResponse>
    {
        public int BarangayId { get; set; }
        public ChangeBarangayStatDto ChangeBarangayStatDto { get; set; }
    }
}
