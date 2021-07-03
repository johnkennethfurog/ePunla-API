using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetCropsHandler : IRequestHandler<GetCropsQuery, MediatrResponse<PageResponseDto<CropDto>>>
    {
        private readonly IMasterListContext _masterListContext;
        private readonly IMapper _mapper;

        public GetCropsHandler(IMasterListContext masterListContext, IMapper mapper)
        {
            _masterListContext = masterListContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<PageResponseDto<CropDto>>> Handle(GetCropsQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _masterListContext.GetCrops(request.SearchRequest);
            var cropsDto = _mapper.Map<IEnumerable<CropDto>>(mediatorResponse.Value);
            var totalCount = mediatorResponse.Value.FirstOrDefault()?.total_count;

            var page = new PageResponse
            {
                TotalCount = totalCount ?? 0
            };

            var pagedResponse = new PageResponseDto<CropDto>
            {
                Page = page,
                Values = cropsDto
            };

            return new MediatrResponse<PageResponseDto<CropDto>>(pagedResponse);
        }
    }
}
