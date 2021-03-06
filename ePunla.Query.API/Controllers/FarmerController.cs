using System.Threading.Tasks;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Query.Business.Queries;
using ePunla.Query.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePunla.Query.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FarmerController : BaseController
    {
        private readonly IMediator _mediator;

        public FarmerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var response = await _mediator.Send(new GetFarmerProfileQuery { FarmerId = GetUserId() });
            return ProcessResponse(response);
        }

        [HttpGet("farms")]
        public async Task<IActionResult> GetFarms([FromQuery] string Status)
        {
            var response = await _mediator.Send(new GetFarmersFarmQuery { FarmerId = GetUserId() , Status = Status });
            return ProcessResponse(response);
        }

        
        [HttpPost("claims/search")]
        public async Task<IActionResult> GetFarms([FromBody] SearchClaimFieldsDto SearchField)
        {
            var response = await _mediator.Send(new GetFarmersClaimQuery { FarmerId = GetUserId(), SearchField = SearchField });
            return ProcessResponse(response);
        }

        [HttpPost("crops/search")]
        public async Task<IActionResult> GetCrops([FromBody] SearchCropFieldsDto SearchField)
        {
            var response = await _mediator.Send(new GetFarmersCropQuery { FarmerId = GetUserId(), SearchField = SearchField });
            return ProcessResponse(response);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var response = await _mediator.Send(new GetFarmerDashboardQuery());
            return ProcessResponse(response);
        }
    }
}
