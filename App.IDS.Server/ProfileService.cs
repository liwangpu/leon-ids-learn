using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.IDS.Server
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //var claims = new List<Claim>();
            //claims.Add(new Claim("aa", "123456"));
            //claims.Add(new Claim("bb", "18"));

            //context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
      
        }
    }
}
