using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class CropHarvestCommand : IRequest<MediatrResponse>
    {
        public int FarmCropId { get; set; }
        public CropHarvestDto CropHarvestDto { get; set; }
    }
}
