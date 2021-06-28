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

namespace ePunla.Query.Business.AdminQueries
{
    public class GetClaimsHandler : IRequestHandler<GetClaimsQuery, MediatrResponse<PageResponseDto<ClaimDto>>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;
        private readonly IFarmerContext _farmerContext;

        public GetClaimsHandler(IAdminContext adminContext, IMapper mapper, IFarmerContext farmerContext)
        {
            _adminContext = adminContext;
            _mapper = mapper;
            _farmerContext = farmerContext;
        }

        public async Task<MediatrResponse<PageResponseDto<ClaimDto>>> Handle(GetClaimsQuery request, CancellationToken cancellationToken)
        {
            var claimsMediatorResponse = await _adminContext.GetClaims(request.SearchRequest);
            var claimsModel = claimsMediatorResponse.Value;
            var claimIds = claimsModel.Select(x => x.ClaimId);
            var claimsDto = _mapper.Map<IEnumerable<ClaimDto>>(claimsModel);
            var totalCount = claimsModel.FirstOrDefault()?.total_count;

            var damageCausesMediatorResponse = await _farmerContext.GetDamageCause(claimIds);
            var damageCauses = damageCausesMediatorResponse.Value;


            claimsDto.ToList().ForEach(claim =>
            {
                var claimDamageCause = damageCauses.Where(dc => dc.ClaimId == claim.ClaimId);
                var claimDamageCauseDto = _mapper.Map<IEnumerable<ClaimDamageCauseDto>>(claimDamageCause);

                claim.DamageCause = claimDamageCauseDto;
            });

            var page = new PageResponse
            {
                TotalCount = totalCount ?? 0
            };

            var pagedResponse = new PageResponseDto<ClaimDto>
            {
                Page = page,
                Values = claimsDto
            };

            return new MediatrResponse<PageResponseDto<ClaimDto>>(pagedResponse);
        }
    }
}
