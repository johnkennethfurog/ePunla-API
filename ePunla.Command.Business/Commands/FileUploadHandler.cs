using System;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.Business.Services.Interfaces;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.Response;
using MediatR;

namespace ePunla.Command.Business.Commands
{
    public class FileUploadHandler : IRequestHandler<FileUploadCommand, MediatrResponse<UploadResultDto>>
    {
        private readonly IPhotoService _photoService;

        public FileUploadHandler(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<MediatrResponse<UploadResultDto>> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            var photoResult = await _photoService.UploadDocument(request.FormFile);

            return new MediatrResponse<UploadResultDto>(photoResult);
        }
    }
}
