using System.Threading.Tasks;
using ePunla.Command.Business.Commands;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Common.Utilitites.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class FarmerController : BaseController
    {
        private readonly IMediator _mediator;

        public FarmerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterFarmerDto registerFarmerDto)
        {
            var response = await _mediator.Send(new RegisterFarmerCommand { RegisterFarmerDto = registerFarmerDto });
            return ProcessResponse(response);
        }

        [HttpDelete("crops/{cropId}")]
        public async Task<IActionResult> DeleteCrop(int cropId)
        {
            var response = await _mediator.Send(new CropDeleteCommand { FarmCropId = cropId });
            return ProcessResponse(response);
        }

        [HttpPut("crops/{cropId}/harvest")]
        public async Task<IActionResult> HarvestCrop(int cropId, [FromBody] CropHarvestDto cropHarvestDto)
        {
            var response = await _mediator.Send(new CropHarvestCommand { FarmCropId = cropId, CropHarvestDto = cropHarvestDto });
            return ProcessResponse(response);
        }

        [HttpPost("crops/save")]
        public async Task<IActionResult> SaveCrop([FromBody] FarmCropSaveDto farmCropSaveDto)
        {
            var response = await _mediator.Send(new FarmCropSaveCommand { FarmerId = UserHelper.GetUserId(), FarmCropSaveDto = farmCropSaveDto });
            return ProcessResponse(response);
        }

        [HttpPost("farms/save")]
        public async Task<IActionResult> SaveFarm([FromBody] FarmSaveDto farmSaveDto)
        {
            var response = await _mediator.Send(new SaveFarmCommand { FarmerId = UserHelper.GetUserId(), FarmSaveDto = farmSaveDto });
            return ProcessResponse(response);
        }

        [HttpDelete("claims/{claimId}")]
        public async Task<IActionResult> DeleteClaim(int claimId)
        {
            var response = await _mediator.Send(new DeleteClaimCommand { ClaimId = claimId });
            return ProcessResponse(response);
        }
    }
}
