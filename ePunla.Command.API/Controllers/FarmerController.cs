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
        public async Task<IActionResult> GetFarms(RegisterFarmerDto registerFarmerDto)
        {
            var response = await _mediator.Send(new RegisterFarmerCommand { RegisterFarmerDto = registerFarmerDto });
            return ProcessResponse(response);
        }
    }
}
