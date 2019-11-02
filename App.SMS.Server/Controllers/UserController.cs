using App.SMS.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace App.SMS.Server.Controllers
{
    [Route("sms/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var users = userRepository.GetAll();


            var claims = from c in User.Claims
                         select new { c.Type, c.Value };

            return Ok(new { Users = users, Claims = claims, User.Identity, Header = Request.Headers });
        }

        [HttpPost]
        public IActionResult Post(UserCreateModel model)
        {
            userRepository.Create(model.Name);
            return Ok(model.Name);
        }
    }


    public class UserCreateModel
    {
        public string Name { get; set; }
    }
}