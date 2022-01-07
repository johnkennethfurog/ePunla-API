using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePunla.Command.Business.AdminCommands;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.BaseClass;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : BaseController
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("farms/{farmId}/validate")]
        public async Task<IActionResult> ValidateFarm(int farmId, [FromBody] ValidateFarmDto validateFarmDto)
        {
            var response = await _mediator.Send(new ValidateFarmCommand { ValidateFarmDto = validateFarmDto, FarmId = farmId });
            return ProcessResponse(response);
        }

        [HttpPut("claims/{claimId}/validate")]
        public async Task<IActionResult> ValidateClaim(int claimId, [FromBody] ValidateClaimDto validateClaimDto)
        {
            var response = await _mediator.Send(new ValidateClaimCommand { ValidateClaimDto = validateClaimDto, ClaimId = claimId });
            return ProcessResponse(response);
        }

        [HttpPut("claims/{claimId}/setforverification")]
        public async Task<IActionResult> SetForVerification(int claimId)
        {
            var response = await _mediator.Send(new SetClaimForVerificationCommand { ClaimId = claimId });
            return ProcessResponse(response);
        }

        [HttpPut("claims/{claimId}/setasclaimed")]
        public async Task<IActionResult> SetAsClaimed(int claimId)
        {
            var response = await _mediator.Send(new SetClaimAsClaimedCommand { ClaimId = claimId });
            return ProcessResponse(response);
        }
    }
}
