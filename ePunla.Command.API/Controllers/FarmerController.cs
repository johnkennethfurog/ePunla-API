using System.Threading.Tasks;
using ePunla.Command.Business.Commands;
using ePunla.Command.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class FarmerController : Controller
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

            if(response.IsInvalid)
                return BadRequest(response.ErrorMessages);
            else
                return Ok(response.Value);
        }
    }
}
