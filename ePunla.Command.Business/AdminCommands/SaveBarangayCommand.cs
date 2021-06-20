using System;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class SaveBarangayCommand : IRequest<MediatrResponse<int>>
    {
        public SaveBarangayDto SaveBarangayDto { get; set; }
    }
}
