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
    public class GetFarmersClaimHandler : IRequestHandler<GetFarmersClaimQuery, MediatrResponse<IEnumerable<FarmerClaimDto>>>
    {
        private readonly IFarmerContext _farmerContext;
        private readonly IMapper _mapper;

        public GetFarmersClaimHandler(IFarmerContext farmerContext, IMapper mapper)
        {
            _farmerContext = farmerContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<FarmerClaimDto>>> Handle(GetFarmersClaimQuery request, CancellationToken cancellationToken)
        {
            var claimsMediatorResponse = await _farmerContext.GetClaims(request.FarmerId, request.SearchField);
            var claimsModel = claimsMediatorResponse.Value;
            var claimIds = claimsModel.Select(x => x.ClaimId);
            var claimsDto = _mapper.Map<IEnumerable<FarmerClaimDto>>(claimsModel);

            var damageCausesMediatorResponse = await _farmerContext.GetDamageCause(claimIds);
            var damageCauses = damageCausesMediatorResponse.Value;


            claimsDto.ToList().ForEach(claim =>
            {
                var claimDamageCause = damageCauses.Where(dc => dc.ClaimId == claim.ClaimId);
                var claimDamageCauseDto = _mapper.Map<IEnumerable<ClaimDamageCauseDto>>(claimDamageCause);

                claim.DamageCause = claimDamageCauseDto;
            });

            return new MediatrResponse<IEnumerable<FarmerClaimDto>>(claimsDto);
        }
    }
}
