using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;

namespace App.APIGateway.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationProviderKey = "SMSKey";
            Action<IdentityServerAuthenticationOptions> options = o =>
            {
                //o.Authority = "http://192.168.99.100";
                //o.ApiName = "smsApi";
                o.SupportedTokens = SupportedTokens.Reference;
                //o.ApiSecret = "secret";

                o.Authority = "http://192.168.99.100:5000";
                o.ApiName = "smsApi";
                o.ApiSecret = "654321";
                o.RequireHttpsMetadata = false;
            };

            services.AddAuthentication()
                .AddIdentityServerAuthentication(authenticationProviderKey, options);



            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseOcelot().Wait();
        }
    }
}
