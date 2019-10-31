using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.SMS.Server.Controllers
{
    [Route("sms/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var res = new List<string> { "user1", "user2" };
            return Ok(res);
        }
    }
}