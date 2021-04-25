using System;
using System.Threading.Tasks;
using ePunla.Command.Domain.Dtos;
using Microsoft.AspNetCore.Http;

namespace ePunla.Command.Business.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<UploadResultDto> UploadDocument(IFormFile formFile);
    }
}
