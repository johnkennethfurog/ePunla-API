using System;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ePunla.Command.Business.Services.Interfaces;
using ePunla.Command.Domain.Dtos;
using Microsoft.AspNetCore.Http;

namespace ePunla.Command.Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService()
        {
            var cloudName = Environment.GetEnvironmentVariable("CLOUDINART_SETTINGS_CLOUD_NAME");
            var apiKey = Environment.GetEnvironmentVariable("CLOUDINART_SETTINGS_API_KEY");
            var apiSecret = Environment.GetEnvironmentVariable("CLOUDINART_SETTINGS_API_SECRET");
            var acc = new Account(cloudName, apiKey, apiSecret);

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

