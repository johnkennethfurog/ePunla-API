using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using ePunla.Query.Domain.Enums;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetClaimDetailHandler : IRequestHandler<GetClaimDetailQuery, MediatrResponse<ClaimDetailDto>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;
        private readonly IFarmerContext _farmerContext;

        public GetClaimDetailHandler(IAdminContext adminContext, IMapper mapper, IFarmerContext farmerContext)
        {
            _adminContext = adminContext;
            _mapper = mapper;
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse<ClaimDetailDto>> Handle(GetClaimDetailQuery request, CancellationToken cancellationToken)
        {
            var contextResponse = await _adminContext.GetClaimDetail(request.ClaimId);

            if (!contextResponse.IsValid)
            {
                var error = (ErrorCode)contextResponse.ErrorCode;
                switch (error)
                {
                    case ErrorCode.ClaimNotFound:
                        return new MediatrResponse<ClaimDetailDto>(new ErrorMessage("Claim does not exist"));
                }
            }

            var claimsDto = _mapper.Map<ClaimDetailDto>(contextResponse.Value);

            var damageCausesMediatorResponse = await _farmerContext.GetDamageCause(new List<int> { claimsDto.ClaimId });
            var damageCauses = damageCausesMediatorResponse.Value;

            claimsDto.DamageCause = _mapper.Map<IEnumerable<ClaimDamageCauseDto>>(damageCauses);
            claimsDto.TotalDamagedArea = (int) damageCauses.Sum(x => x.DamagedAreaSize);

            return new MediatrResponse<ClaimDetailDto>(claimsDto);
        }
    }
}
