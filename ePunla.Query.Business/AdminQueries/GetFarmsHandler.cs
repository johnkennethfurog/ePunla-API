using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetFarmsHandler : IRequestHandler<GetFarmsQuery, MediatrResponse<IEnumerable<FarmDto>>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;

        public GetFarmsHandler(IAdminContext adminContext, IMapper mapper)
        {
            _adminContext = adminContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<FarmDto>>> Handle(GetFarmsQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _adminContext.GetFarms(request.SearchRequest);
            var farmsDto = _mapper.Map<IEnumerable<FarmDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<FarmDto>>(farmsDto);
        }
    }
}
