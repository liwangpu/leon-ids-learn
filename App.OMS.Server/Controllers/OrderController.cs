using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.OMS.Server.Controllers
{
    [Route("oms/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var res = new List<string> { "order1", "order2" };
            return Ok(res);
        }
    }
}