using System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet("checkEnv/{key}")]
        public string Env(string key)
        {
            // some changes
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
