using G8I9DY_HFT_2021221.Data;
using G8I9DY_HFT_2021221.Logic;
using G8I9DY_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IAlbumLogic, AlbumLogic>();
            services.AddTransient<IArtistLogic, ArtistLogic>();
            services.AddTransient<ITrackLogic, TrackLogic>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<ITrackRepository, TrackRepository>();
            services.AddTransient<TracksDbContext,TracksDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:59654"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
