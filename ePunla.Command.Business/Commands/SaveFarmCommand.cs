using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class SaveFarmCommand : IRequest<MediatrResponse<int>>
    {
        public int FarmerId { get; set; }
        public FarmSaveDto FarmSaveDto { get; set; }
    }
}
