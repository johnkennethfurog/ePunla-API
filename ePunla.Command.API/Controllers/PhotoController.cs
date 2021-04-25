using System.Threading.Tasks;
using ePunla.Command.Business.Commands;
using ePunla.Common.Utilitites.BaseClass;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : BaseController
    {
        private readonly IMediator _mediator;

        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var response = await _mediator.Send(new FileUploadCommand { FormFile = file });
            return ProcessResponse(response);
        }
    }
}
