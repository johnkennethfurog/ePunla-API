using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmersFarmHandler : IRequestHandler<GetFarmersFarmQuery, MediatrResponse<IEnumerable<FarmDto>>>
    {
        private readonly IFarmerContext _farmerContext;
        private readonly IMapper _mapper;

        public GetFarmersFarmHandler(IFarmerContext farmerContext, IMapper mapper)
        {
            _farmerContext = farmerContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<FarmDto>>> Handle(GetFarmersFarmQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _farmerContext.GetFarms(request.FarmerId, request.Status);
            var farmsDto = _mapper.Map<IEnumerable<FarmDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<FarmDto>>(farmsDto);
        }
    }
}
