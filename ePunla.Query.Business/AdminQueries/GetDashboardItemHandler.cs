using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using ePunla.Query.Domain.Enums;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetDashboardItemHandler : IRequestHandler<GetDashboardItemQuery, MediatrResponse<StatDashboardDto>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;

        public GetDashboardItemHandler(IAdminContext adminContext, IMapper mapper)
        {
            _adminContext = adminContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<StatDashboardDto>> Handle(GetDashboardItemQuery request, CancellationToken cancellationToken)
        {
            var response = await _adminContext.GetStatistic();
            var statDashboardModel = response.Value;

            var cropPerBarangayModel = statDashboardModel.StatCropPerBarangayModel;
            var cropStatusPerBarangayModel = statDashboardModel.StatCropStatusPerBarangayModel;
            var farmersPerBarangayModel = statDashboardModel.FarmerPerBarangayModel;



            var farmerPerBarangayDto = _mapper.Map<IEnumerable<StatFarmerPerBarangayDto>>(statDashboardModel.StatFarmerPerBarangayModel);
            var statCountDto = _mapper.Map<StatCountDto>(statDashboardModel.StatCountModel);


           
            // Group crops per barangay
            var groupedCrop = cropPerBarangayModel
                .GroupBy(b => b.BarangayId)
                .Select(b =>
                            new
                            {
                                b.First().Barangay,
                                b.First().Lat,
                                b.First().Lng,
                                b.First().BarangayId,
                                Crops = b.Select(c => new { c.Crop, c.CropsCount })
                            });

            // get percentage of crop for each barangay
            var cropPerBarangayDto = new List<StatCropPerBarangayDto>();
            groupedCrop.ToList().ForEach(g =>
            {
                var cropsListDto = new List<StatCrop>();
                var totalCount = g.Crops.Sum(x => x.CropsCount);
                decimal totalCropsCount = (decimal)totalCount;

                g.Crops.ToList().ForEach(c =>
                {
                    decimal percentage = ((decimal)c.CropsCount / totalCropsCount) * 100;
                    cropsListDto.Add(new StatCrop { Crop = c.Crop, Percentage = percentage, Count = c.CropsCount });
                });

                cropPerBarangayDto.Add(new StatCropPerBarangayDto
                {
                    Barangay = g.Barangay,
                    BarangayId = g.BarangayId,
                    Lat = g.Lat,
                    Lng = g.Lng,
                    TotalCount= totalCount,
                    Crops = cropsListDto
                });
            });


            // Group crops per barangay
            var groupedCropPerStatus = cropStatusPerBarangayModel
                 .GroupBy(b => b.BarangayId)
                 .Select(b =>
                             new
                             {
                                 b.First().Barangay,
                                 b.First().BarangayId,
                                 CropCountPerStatus = b.Select(c => new { c.Status, c.CropsCount })
                             });

            var cropPerStatusPerBarangayDto = new List<StatCropStatusPerBarangayDto>();
            // get crop count per status per barangay
            groupedCropPerStatus.ToList().ForEach(g =>
            {
                var damaged = g.CropCountPerStatus.FirstOrDefault(x => x.Status == CropStatus.Damaged.ToString())?.CropsCount ?? 0;
                var planted = g.CropCountPerStatus.FirstOrDefault(x => x.Status == CropStatus.Planted.ToString())?.CropsCount ?? 0;
                var harvested = g.CropCountPerStatus.FirstOrDefault(x => x.Status == CropStatus.Harvested.ToString())?.CropsCount ?? 0;

                cropPerStatusPerBarangayDto.Add(new StatCropStatusPerBarangayDto
                {
                    Barangay = g.Barangay,
                    BarangayId = g.BarangayId,
                    Damaged = damaged,
                    Planted = planted,
                    Harvested = harvested
                });
            });

            // get farmers per barangay
            var groupedFarmersPerBarangay = farmersPerBarangayModel
                .GroupBy(b => b.BarangayId)
                .Select(b =>
                            new
                            {
                                b.First().Barangay,
                                b.First().BarangayId,
                                Farmers = b.Select(c => new { c.FirstName, c.LastName, c.MobileNumber, c.StreetAddress, c.FarmerId })
                            });
            var groupedFarmersPerBarangayDto = new List<FarmerPerBarangayDto>();
            groupedFarmersPerBarangay.ToList().ForEach(x =>
            {
                var farmerPerBarangayDto = new FarmerPerBarangayDto
                {
                    Barangay = x.Barangay,
                    BarangayId = x.BarangayId,
                    Farmers = x.Farmers as IEnumerable<FarmerPerBarangay>
                };

                groupedFarmersPerBarangayDto.Add(farmerPerBarangayDto);
            });


            var statDashboardDto = new StatDashboardDto
            {
                StatCropStatusPerBarangayDto = cropPerStatusPerBarangayDto,
                StatFarmerPerBarangayDto = farmerPerBarangayDto,
                StatCropPerBarangayDto = cropPerBarangayDto,
                StatCountDto = statCountDto,
                FarmerPerBarangayDto = groupedFarmersPerBarangayDto
            };

            return new MediatrResponse<StatDashboardDto>(statDashboardDto);
        }
    }
}
