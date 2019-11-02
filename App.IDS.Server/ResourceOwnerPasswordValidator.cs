using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.IDS.Server
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("aa", "123"));

            context.Result = new GrantValidationResult("1", "custom", claims);
        }
    }
}
