using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.IDS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersistedGrantController : ControllerBase
    {
        private readonly IPersistedGrantStore persistedGrantStore;

        public PersistedGrantController(IPersistedGrantStore persistedGrantStore)
        {
            this.persistedGrantStore = persistedGrantStore;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var grant = await persistedGrantStore.GetAsync("pPh6/ZaYcCb7FpOwD7bxRkn7rDwsBFFnHbob2VzTZUc=");

            return Ok(grant);
        }
    }
}