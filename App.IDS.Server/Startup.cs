using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace App.IDS.Server
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

            const string configConnectionString = @"server=122.51.54.26;userid=root;password=root;database=ids.config;";
            const string operateConnectionString = @"server=122.51.54.26;userid=root;password=root;database=ids.operation;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;


            var builder = services.AddIdentityServer()
                 //.AddConfigurationStore(options =>
                 //   {
                 //       options.ConfigureDbContext = b =>
                 //           b.UseMySQL(configConnectionString,
                 //               sql => sql.MigrationsAssembly(migrationsAssembly));
                 //   })
                .AddOperationalStore(options =>
                 {
                     options.ConfigureDbContext = b =>
                         b.UseMySQL(operateConnectionString,
                             sql => sql.MigrationsAssembly(migrationsAssembly));

                     // this enables automatic token cleanup. this is optional.
                     options.EnableTokenCleanup = true;
                 })

            .AddInMemoryIdentityResources(Config.Ids)
            .AddInMemoryApiResources(Config.GetApis())
            .AddInMemoryClients(Config.GetClients());

            builder.AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIdentityServer();
        }
    }
}
