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
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;

        public GetCropsHandler(IAdminContext adminContext, IMapper mapper)
        {
            _adminContext = adminContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<CropDto>>> Handle(GetCropsQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _adminContext.GetCrops();
            var categoriesDto = _mapper.Map<IEnumerable<CropDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<CropDto>>(categoriesDto);
        }
    }
}
