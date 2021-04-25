using System;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ePunla.Command.Business.Services.Interfaces;
using ePunla.Command.Business.Utilities;
using ePunla.Command.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ePunla.Command.Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySetting> config)
        {
            var acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<UploadResultDto> UploadDocument(IFormFile formFile)
        {
            using var stream = formFile.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(formFile.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return new UploadResultDto
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.Url.AbsoluteUri
            };
        }
    }
}

