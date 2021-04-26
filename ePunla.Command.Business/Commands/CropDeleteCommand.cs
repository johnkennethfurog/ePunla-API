using System;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class CropDeleteCommand : IRequest<MediatrResponse>
    {
        public int FarmCropId { get; set; }
    }
}
