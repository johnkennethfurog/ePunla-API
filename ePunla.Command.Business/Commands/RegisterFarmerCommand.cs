using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utillities.Dtos;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class RegisterFarmerCommand : IRequest<MediatrResponse<FarmerResponseDto>>
    {
        public RegisterFarmerDto RegisterFarmerDto { get; set; }

        public RegisterFarmerCommand(){}
    }
}
