using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetBarangaysAndAreasHandler : IRequestHandler<GetBarangaysAndAreasQuery, MediatrResponse<IEnumerable<BarangayDto>>>
    {
        private readonly IMasterListContext _context;
        private readonly IMapper _mapper;

        public GetBarangaysAndAreasHandler(IMasterListContext cropsContext, IMapper mapper)
        {
            _context = cropsContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<BarangayDto>>> Handle(GetBarangaysAndAreasQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _context.GetBarangaysAndArea();
            var values = mediatorResponse.Value;

            var barangays = _mapper.Map<IEnumerable<BarangayDto>>(values);
            var barangayDtos = barangays.GroupBy(x => x.BarangayId).Select(x => x.First());

            foreach (var brgy in barangayDtos)
            {
                var areas = values.ToList().Where(area => area.BarangayId == brgy.BarangayId);
                var areDtos = _mapper.Map<IEnumerable<AreaDto>>(areas);

                brgy.Areas = areDtos;
            }

            return new MediatrResponse<IEnumerable<BarangayDto>>(barangayDtos);
        }
    }
}
