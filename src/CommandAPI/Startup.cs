

using System;
using AutoMapper;
using CommandAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace CommandAPI
{
    public class Startup
    {
        // We provide an access to Configration api
        // via emplementing [IConfigration] interface witch means we can access the configration stored in [appsetting.json]
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          var builder = new NpgsqlConnectionStringBuilder();
            builder.ConnectionString = 
                Configuration.GetConnectionString("PostgreSqlConnection");
                builder.Username = Configuration["UserID"];
                builder.Password = Configuration["Password"];

            services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(builder.ConnectionString));


            services.AddControllers(); /// Rrgister the services to enable the use of [controllers]

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>(); /// Dependincy injuction

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //MIDDLEWARE
                app.UseDeveloperExceptionPage();
            }

            //MIDDLEWARE
            app.UseRouting();

            //MIDDLEWARE
            app.UseEndpoints(endpoints =>
            {
                /// Register [configration services] as endpoint in the request Pipeline
                endpoints.MapControllers(); 
              
            });
        }
    }
}
