using CityWeather.Application;
using CityWeather.Application.Interfaces;
using CityWeather.Data;
using CityWeather.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityWeather.API
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

            services.AddSingleton<IConfiguration>(Configuration);

            // DI - Maybe use a third party?
            services.AddSingleton<IAddCityUseCase, AddCityUseCase>();
            services.AddSingleton<IDeleteCityUseCase, DeleteCityUseCase>();
            services.AddSingleton<ISearchCityUseCase, SearchCityUseCase>();
            services.AddSingleton<IUpdateCityUseCase, UpdateCityUseCase>();

            services.AddSingleton<IValidator, Validator>();

            services.AddSingleton<ICitiesRepository, CitiesRepository>();
            services.AddSingleton<ICountryInfoRepository, CountryInfoRepository>();
            services.AddSingleton<IWeatherInfoRepository, WeatherInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
