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

namespace ePunla.Query.Business.Queries
{
    public class GetFarmerDashboardHandler : IRequestHandler<GetFarmerDashboardQuery, MediatrResponse<FarmerDashboardDto>>
    {
        private readonly IFarmerContext _farmerContext;
        private readonly IMapper _mapper;
        const int TOP = 5;

        public GetFarmerDashboardHandler(IFarmerContext farmerContext, IMapper mapper)
        {
            _farmerContext = farmerContext;
            _mapper = mapper;
        }


        public async Task<MediatrResponse<FarmerDashboardDto>> Handle(GetFarmerDashboardQuery request, CancellationToken cancellationToken)
        {
            var response = await _farmerContext.GetDashboard();
            var dashboardModel = response.Value;

            

            var topPlanted = dashboardModel.Where(x => x.Status == "Planted").OrderByDescending(x => x.AreaSize).Take(TOP);
            var topDamaged = dashboardModel.Where(x => x.Status == "Damaged").OrderByDescending(x => x.AreaSize).Take(TOP);
            var topHarvested = dashboardModel.Where(x => x.Status == "Harvested").OrderByDescending(x => x.AreaSize).Take(TOP);


            var topPlantedDto = _mapper.Map<IEnumerable<FarmerDashboardCropStatDto>>(topPlanted);
            var topDamagedDto = _mapper.Map<IEnumerable<FarmerDashboardCropStatDto>>(topDamaged);
            var topHarvestedDto = _mapper.Map<IEnumerable<FarmerDashboardCropStatDto>>(topHarvested);

            return new MediatrResponse<FarmerDashboardDto>(new FarmerDashboardDto
            {
                Damaged = topDamagedDto,
                Planted = topPlantedDto,
                Harvested = topHarvestedDto

            });
        }
    }
}
