using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Order.Server
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication("Bearer")
             .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.ApiName = "orderApi";
                    options.ApiSecret = "123456";

                    //options.ClientId = "orderapp";
                    //options.ClientSecret = "secret";

                    options.RequireHttpsMetadata = false;

                    //options.Audience = "orderApi";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
