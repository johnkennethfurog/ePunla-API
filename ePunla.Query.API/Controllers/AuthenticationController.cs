using System.Threading.Tasks;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Query.Business.Queries;
using ePunla.Query.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Query.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("farmer")]
        public async Task<IActionResult> Signin([FromBody] SigninFarmerDto signinFarmerDto)
        {
            var response = await _mediator.Send(new SigninFarmerQuery {SigninFarmerDto = signinFarmerDto });
            return ProcessResponse(response);
        }

        [HttpGet("ValidateMobileNumber/{mobileNumber}")]
        public async Task<IActionResult> ValidateMobileNumber(string mobileNumber)
        {
            var response = await _mediator.Send(new ValidateFarmerMobileNumberQuery { MobileNumber= mobileNumber });
            return ProcessResponse(response);
        }
    }
}
