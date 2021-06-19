using System.Threading.Tasks;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Query.Business.AdminQueries;
using ePunla.Query.Business.Queries;
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
        [HttpGet("crops")]
        public async Task<IActionResult> GetCrops()
        {
            var response = await _mediator.Send(new GetCropsQuery());
            return ProcessResponse(response);
        }
    }
}
