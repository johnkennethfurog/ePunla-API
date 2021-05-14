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
    public class CropsController : BaseController
    {
        private readonly IMediator _mediator;

        public CropsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("lookup")]
        public async Task<IActionResult> CropsLookup([FromBody] PageRequestDto<CropsLookupFieldsDto> request)
        {
            var response = await _mediator.Send(new CropLookupQuery { CropsLookupFields = request });
            return ProcessResponse(response);
        }
    }
}
