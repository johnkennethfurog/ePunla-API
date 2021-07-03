using System.Threading.Tasks;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Query.Business.AdminQueries;
using ePunla.Query.Business.Queries;
using ePunla.Query.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePunla.Query.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MasterListController : BaseController
    {
        private readonly IMediator _mediator;

        public MasterListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("barangays")]
        public async Task<IActionResult> GetFarms()
        {
            var response = await _mediator.Send(new GetBarangaysAndAreasQuery());
            return ProcessResponse(response);
        }

        [AllowAnonymous]
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _mediator.Send(new GetCategoriesQuery());
            return ProcessResponse(response);
        }

        [AllowAnonymous]
        [HttpPost("crops")]
        public async Task<IActionResult> GetCrops([FromBody] PageRequestDto<SearchAdminCropFieldsDto> searchRequest)
        {
            var response = await _mediator.Send(new GetCropsQuery { SearchRequest = searchRequest });
            return ProcessResponse(response);
        }
    }
}
