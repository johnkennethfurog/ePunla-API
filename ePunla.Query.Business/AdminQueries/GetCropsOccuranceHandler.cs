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
    public class GetCropsOccuranceHandler : IRequestHandler<GetCropsOccuranceQuery, MediatrResponse<IEnumerable<CropsOccuranceDto>>>
    {
        private readonly IAdminContext _context;
        private readonly IMapper _mapper;

        public GetCropsOccuranceHandler(IAdminContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<CropsOccuranceDto>>> Handle(GetCropsOccuranceQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _context.GetCropsOccurance(request.CropsOccuranceLookupFields);
            var occuranceDtos = _mapper.Map<IEnumerable<CropsOccuranceDto>>(mediatorResponse.Value);
            return new MediatrResponse<IEnumerable<CropsOccuranceDto>>(occuranceDtos);
        }
    }
}
