using AutoMapper;
using ePunla.Common.Utillities.Dtos;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.Business.Configurations
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<FarmModel, FarmDto>();
            CreateMap<FarmCropModel, FarmCropDto>();

            CreateMap<FarmerClaimModel, FarmerClaimDto>();
            CreateMap<ClaimDamageCauseModel, ClaimDamageCauseDto>();

            CreateMap<FarmerModel, FarmerProfileDto>();

            CreateMap<LookupModel, LookupDto>();

            CreateMap<BarangayAndAreaModel, BarangayDto>();
            CreateMap<BarangayAndAreaModel, AreaDto>();
        }
    }
}
