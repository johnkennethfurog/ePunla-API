using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class RegisterFarmerCommand : IRequest<MediatrResponse<int>>
    {
        public RegisterFarmerDto RegisterFarmerDto { get; set; }

        public RegisterFarmerCommand()
        {

        }
    }
}
