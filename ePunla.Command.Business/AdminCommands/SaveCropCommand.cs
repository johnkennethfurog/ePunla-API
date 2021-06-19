using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class SaveCropCommand : IRequest<MediatrResponse<int>>
    {
        public SaveCropDto SaveCropDto { get; set; }
    }
}
