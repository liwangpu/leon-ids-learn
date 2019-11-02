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
        public IConfiguration Configuration { get; }

        public string IdentityServerAuthority => Configuration["IdentityServer:Authority"];
        public string IdentityServerClientId => Configuration["IdentityServer:ClientId"];
        public string IdentityServerAPISecret => Configuration["IdentityServer:ApiSecret"];     
        public bool IdentityServerRequireHttpsMetadata => Convert.ToBoolean(Configuration["IdentityServer:RequireHttpsMetadata"]);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationProviderKey = "OcelotClient";
            Action<IdentityServerAuthenticationOptions> options = o =>
            {
                o.Authority = IdentityServerAuthority;
                o.RequireHttpsMetadata = IdentityServerRequireHttpsMetadata;
                o.SupportedTokens = SupportedTokens.Reference;

                o.ApiName = "ocelotApi";
                o.ApiSecret = "88888888";

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
