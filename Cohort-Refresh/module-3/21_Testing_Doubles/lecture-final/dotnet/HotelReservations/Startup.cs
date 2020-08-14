using System;
using HotelReservations.Dao;
using HotelReservations.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservations
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

            // This registers the HotelDao; The first argument is the type (interface) and the 2nd argument here is the class(implantation)
            services.AddSingleton<IHotelDao, HotelDao>();

            services.AddSingleton<IReviewDao, ReviewDao>();

            services.AddSingleton<EmailNotificationService>();

            services.AddSingleton<SmsNotificationService>();

            // Add CORS policy allowing any origin
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
          builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
