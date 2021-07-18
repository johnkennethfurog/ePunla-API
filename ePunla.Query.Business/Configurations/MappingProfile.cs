using AutoMapper;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.Business.Configurations
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<FarmerFarmModel, FarmerFarmDto>();
            CreateMap<FarmCropModel, FarmCropDto>();

            CreateMap<FarmerClaimModel, FarmerClaimDto>();
            CreateMap<ClaimDamageCauseModel, ClaimDamageCauseDto>();

            CreateMap<FarmerModel, FarmerProfileDto>();

            CreateMap<LookupModel, LookupDto>();

            CreateMap<BarangayAndAreaModel, BarangayDto>();
            CreateMap<BarangayAndAreaModel, AreaDto>();

            // Admin
            CreateMap<FarmModel, FarmDto>();
            CreateMap<ClaimModel, ClaimDto>();
            CreateMap<CategoryModel, CategoryDto>();
            CreateMap<CropModel, CropDto>();
            CreateMap<ClaimDetailModel, ClaimDetailDto>();
        }
    }
}
