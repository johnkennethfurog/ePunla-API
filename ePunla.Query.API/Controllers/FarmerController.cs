using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Common.Utilitites.Helpers;
using ePunla.Query.Business.Queries;
using ePunla.Query.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Query.API.Controllers
{
    [Route("api/[controller]")]
    public class FarmerController : BaseController
    {
        private readonly IMediator _mediator;

        public FarmerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("farms")]
        public async Task<IActionResult> GetFarms()
        {
            var response = await _mediator.Send(new GetFarmersFarmQuery { FarmerId = UserHelper.GetUserId() });
            return ProcessResponse(response);
        }

        [HttpPost("claims/search")]
        public async Task<IActionResult> GetFarms([FromBody] SearchClaimFieldsDto SearchField)
        {
            var response = await _mediator.Send(new GetFarmersClaimQuery { FarmerId = UserHelper.GetUserId(), SearchField = SearchField });
            return ProcessResponse(response);
        }

        [HttpPost("crops/search")]
        public async Task<IActionResult> GetCrops([FromBody] SearchCropFieldsDto SearchField)
        {
            var response = await _mediator.Send(new GetFarmersCropQuery { FarmerId = UserHelper.GetUserId(), SearchField = SearchField });
            return ProcessResponse(response);
        }
    }
}
