using Surveys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

namespace Surveys
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
            // getting contact context...CHANGE IN APPSETTINGS.JSON
            services.AddDbContext<ContactContext>(opt => opt.UseMySQL
                (Configuration.GetConnectionString("SurveysConnection")));

            // getting artist context...CHANGE IN APPSETTINGS.JSON
            services.AddDbContext<ArtistContext>(opt => opt.UseMySQL
                (Configuration.GetConnectionString("SurveysConnection")));

            // creating mapper instance
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // importing controllers
            services.AddControllers();

            // add scoped repositories here...
            services.AddScoped<IContactRepo, SqlContactRepo>();
            services.AddScoped<IArtistRepo, SqlArtistOfTheWeekRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ie Ok, etc.
            app.UseHttpsRedirection();
            // to match requests to created endpoints
            app.UseRouting();
            
            // potentially app.UseEndpoints then use require auth

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
