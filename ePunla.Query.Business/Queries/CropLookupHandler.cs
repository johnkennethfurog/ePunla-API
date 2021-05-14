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
    public class CropLookupHandler : IRequestHandler<CropLookupQuery, MediatrResponse<IEnumerable<LookupDto>>>
    {
        private readonly ICropsContext _cropsContext;
        private readonly IMapper _mapper;

        public CropLookupHandler(ICropsContext cropsContext, IMapper mapper)
        {
            _cropsContext = cropsContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<LookupDto>>> Handle(CropLookupQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _cropsContext.CropsLookup(request.CropsLookupFields);
            var cropsLookupDto = _mapper.Map<IEnumerable<LookupDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<LookupDto>>(cropsLookupDto);
        }
    }
}
