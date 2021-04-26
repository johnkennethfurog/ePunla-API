using System.Threading.Tasks;
using ePunla.Command.Business.Commands;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.BaseClass;
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
        public async Task<IActionResult> GetFarms([FromBody] RegisterFarmerDto registerFarmerDto)
        {
            var response = await _mediator.Send(new RegisterFarmerCommand { RegisterFarmerDto = registerFarmerDto });
            return ProcessResponse(response);
        }

        [HttpDelete("crops/{cropId}")]
        public async Task<IActionResult> GetFarms(int cropId)
        {
            var response = await _mediator.Send(new CropDeleteCommand { FarmCropId = cropId });
            return ProcessResponse(response);
        }

        [HttpPut("crops/{cropId}/harvest")]
        public async Task<IActionResult> GetFarms(int cropId, CropHarvestDto cropHarvestDto)
        {
            var response = await _mediator.Send(new CropHarvestCommand { FarmCropId = cropId, CropHarvestDto = cropHarvestDto });
            return ProcessResponse(response);
        }
    }
}
