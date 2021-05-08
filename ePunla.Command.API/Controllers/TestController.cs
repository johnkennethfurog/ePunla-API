using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePunla.Command.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET api/values/5
        [HttpGet("{key}")]
        public string Env(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
