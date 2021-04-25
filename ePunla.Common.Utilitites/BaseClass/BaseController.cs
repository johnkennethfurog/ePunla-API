using System;
using ePunla.Common.Utilitites.Response;
using Microsoft.AspNetCore.Mvc;

namespace ePunla.Common.Utilitites.BaseClass
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }


        protected IActionResult ProcessResponse<T>(MediatrResponse<T> response)
        {
            if (response.IsInvalid)
                return BadRequest(response.ErrorMessages);
            else
                return Ok(response.Value);
        }

        protected IActionResult ProcessResponse(MediatrResponse response)
        {
            if (response.IsInvalid)
                return BadRequest(response.ErrorMessages);
            else
                return Ok();
        }
    }
}
