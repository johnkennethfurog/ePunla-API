﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePunla.Command.Business.AdminCommands;
using ePunla.Command.Domain.Dtos;
using ePunla.Common.Utilitites.BaseClass;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class MasterListController : BaseController
    {

        private readonly IMediator _mediator;

        public MasterListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crops/save")]
        public async Task<IActionResult> SaveCrop([FromBody] SaveCropDto saveCropDto)
        {
            var response = await _mediator.Send(new SaveCropCommand { SaveCropDto = saveCropDto });
            return ProcessResponse(response);
        }
    }
}
