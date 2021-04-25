using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ePunla.Command.Business.Commands
{
    public class FileUploadCommand : IRequest<MediatrResponse<UploadResultDto>>
    {
        public IFormFile FormFile { get; set; }
    }
}
