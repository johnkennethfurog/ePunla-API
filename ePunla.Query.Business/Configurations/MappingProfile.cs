using AutoMapper;
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
        }
    }
}
