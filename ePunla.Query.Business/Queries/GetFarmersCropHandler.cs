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
    public class GetFarmersCropHandler : IRequestHandler<GetFarmersCropQuery, MediatrResponse<IEnumerable<FarmCropDto>>>
    {
        private readonly IFarmerContext _farmerContext;
        private readonly IMapper _mapper;

        public GetFarmersCropHandler(IFarmerContext farmerContext, IMapper mapper)
        {
            _farmerContext = farmerContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<FarmCropDto>>> Handle(GetFarmersCropQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _farmerContext.GetCrops(request.FarmerId, request.SearchField);
            var farmCropsDto = _mapper.Map<IEnumerable<FarmCropDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<FarmCropDto>>(farmCropsDto);
        }
    }
}
