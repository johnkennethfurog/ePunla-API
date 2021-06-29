using System;
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
    public class GetFarmsHandler : IRequestHandler<GetFarmsQuery, MediatrResponse<PageResponseDto<FarmDto>>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;

        public GetFarmsHandler(IAdminContext adminContext, IMapper mapper)
        {
            _adminContext = adminContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<PageResponseDto<FarmDto>>> Handle(GetFarmsQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _adminContext.GetFarms(request.SearchRequest);
            var totalCount = mediatorResponse.Value.FirstOrDefault()?.total_count;
            var farmsDto = _mapper.Map<IEnumerable<FarmDto>>(mediatorResponse.Value);

            var page = new PageResponse
            {
                TotalCount = totalCount ?? 0
            };

            var pagedResponse = new PageResponseDto<FarmDto>
            {
                Page = page,
                Values = farmsDto
            };

            return new MediatrResponse<PageResponseDto<FarmDto>>(pagedResponse);
        }
    }
}
