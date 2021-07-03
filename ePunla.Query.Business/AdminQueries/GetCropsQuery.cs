using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetCropsQuery : IRequest<MediatrResponse<PageResponseDto<CropDto>>> {
        public PageRequestDto<SearchAdminCropFieldsDto> SearchRequest { get; set; }
    }
}
