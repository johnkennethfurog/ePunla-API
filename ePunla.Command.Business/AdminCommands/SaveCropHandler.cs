using System;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Command.DAL.interfaces;
using ePunla.Command.Domain.Enums;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using MediatR;

namespace ePunla.Command.Business.AdminCommands
{
    public class SaveCropHandler : IRequestHandler<SaveCropCommand, MediatrResponse<int>>
    {
        private readonly IAdminContext _adminContext;

        public SaveCropHandler(IAdminContext adminContext)
        {
            _adminContext = adminContext;
        }

        public async Task<MediatrResponse<int>> Handle(SaveCropCommand request, CancellationToken cancellationToken)
        {
            var contextResponse = await _adminContext.SaveCrop(request.SaveCropDto);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.CropNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Crop does not exist"));
                    case ErrorCode.CropAlreadyExist:
                        return new MediatrResponse<int>(new ErrorMessage("Crop already exist"));
                    case ErrorCode.CropCategoryNotFound:
                        return new MediatrResponse<int>(new ErrorMessage("Category does not exist"));
                }
            }

            return new MediatrResponse<int>(contextResponse.Value);
        }
    }
}
