﻿using System.Threading.Tasks;
using ePunla.Common.Utilitites.BaseClass;
using ePunla.Query.Business.AdminQueries;
using ePunla.Query.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Query.API.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : BaseController
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("farms")]
        public async Task<IActionResult> GetFarms([FromBody] PageRequestDto<SearchFarmFieldsDto> request)
        {
            var response = await _mediator.Send(new GetFarmsQuery { FarmsLookupFields = request });
            return ProcessResponse(response);
        }
    }
}