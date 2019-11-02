using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.IDS.Server
{
    public class CustomTokenRequestValidator : ICustomTokenRequestValidator
    {
        public async Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("aa", "123"));

            //context.Result = new TokenRequestValidationResult();
        }
    }
}
