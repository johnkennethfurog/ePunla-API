using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class FarmCropSaveCommand : IRequest<MediatrResponse<int>>
    {
        public int FarmerId { get; set; }
        public FarmCropSaveDto FarmCropSaveDto { get; set; }

        public FarmCropSaveCommand()
        {

        }
    }
}
