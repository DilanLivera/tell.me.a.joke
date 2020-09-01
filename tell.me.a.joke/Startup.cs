using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using tell.me.a.joke.HttpClients;
using tell.me.a.joke.Interfaces;
using tell.me.a.joke.Services;

namespace tell.me.a.joke
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpClient<IChuckNorrisClient, ChuckNorrisClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.icndb.com/");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Tell.A.Joke");
            });

            services.AddScoped<IJokeService, JokeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
