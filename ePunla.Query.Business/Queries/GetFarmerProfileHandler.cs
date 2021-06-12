using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using ePunla.Query.Domain.Enums;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmerProfileHandler : IRequestHandler<GetFarmerProfileQuery, MediatrResponse<FarmerProfileDto>>
    {
        private readonly IFarmerContext _farmerContext;
        private readonly IMapper _mapper;

        public GetFarmerProfileHandler(IFarmerContext farmerContext, IMapper mapper)
        {
            _farmerContext = farmerContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<FarmerProfileDto>> Handle(GetFarmerProfileQuery request, CancellationToken cancellationToken)
        {
            var contextResponse = await _farmerContext.GetProfile(request.FarmerId);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.FarmerNotFound:
                        return new MediatrResponse<FarmerProfileDto>(new ErrorMessage("Farmer does not exist"));
                }
            }


            var farmerProfile = _mapper.Map<FarmerProfileDto>(contextResponse.Value);

            return new MediatrResponse<FarmerProfileDto>(farmerProfile);
        }
    }
}
