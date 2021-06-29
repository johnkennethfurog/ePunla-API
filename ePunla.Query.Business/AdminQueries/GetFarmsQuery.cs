using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetFarmsQuery : IRequest<MediatrResponse<PageResponseDto<FarmDto>>>
    {
        public PageRequestDto<SearchFarmFieldsDto> SearchRequest { get; set; }
    }
}
