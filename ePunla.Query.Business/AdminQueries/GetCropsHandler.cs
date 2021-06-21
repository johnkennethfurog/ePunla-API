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
    public class GetCropsHandler : IRequestHandler<GetCropsQuery, MediatrResponse<IEnumerable<CropDto>>>
    {
        private readonly IMasterListContext _masterListContext;
        private readonly IMapper _mapper;

        public GetCropsHandler(IMasterListContext masterListContext, IMapper mapper)
        {
            _masterListContext = masterListContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<CropDto>>> Handle(GetCropsQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _masterListContext.GetCrops();
            var categoriesDto = _mapper.Map<IEnumerable<CropDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<CropDto>>(categoriesDto);
        }
    }
}
