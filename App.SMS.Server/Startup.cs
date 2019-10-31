using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.SMS.Server
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public string IdentityServerAPIName => Configuration["IdentityServer:ApiName"];
        public string IdentityServerAPISecret => Configuration["IdentityServer:ApiSecret"];
        public string IdentityServerAuthority => Configuration["IdentityServer:Authority"];
        public bool IdentityServerRequireHttpsMetadata => Convert.ToBoolean(Configuration["IdentityServer:RequireHttpsMetadata"]);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddAuthentication("Bearer")
            // .AddIdentityServerAuthentication("Bearer", options =>
            // {
            //     options.Authority = IdentityServerAuthority;
            //     options.ApiName = IdentityServerAPIName;
            //     options.ApiSecret = IdentityServerAPISecret;
            //     options.RequireHttpsMetadata = IdentityServerRequireHttpsMetadata;
            // });
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "http://192.168.99.100:5000";
            //    options.RequireHttpsMetadata = false;

            //    options.Audience = "userApi";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}
