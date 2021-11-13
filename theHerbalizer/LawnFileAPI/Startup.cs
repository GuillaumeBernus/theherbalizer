using LawnFile.API.Configuration;
using LawnFile.Domain.Handler;
using LawnFile.Domain.Interface;
using LawnFile.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;

namespace LawnFile.API
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="System.ArgumentNullException">configuration</exception>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                   .AddJsonOptions(opts =>
                   {
                       var enumConverter = new JsonStringEnumConverter();
                       opts.JsonSerializerOptions.Converters.Add(enumConverter);
                       opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                   });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LawnFile.API", Version = "v1" });
            });
            services.Configure<InputFileConfiguration>(_configuration.GetSection("InputFile"));
            services.Configure<FileTreatmentConfiguration>(_configuration.GetSection("FileTreatment"));
            services.AddSingleton<ILawnFileHandler, LawnFileHandler>();
            services.AddSingleton<ILawnApiClient, LawnApiClient>();

            services.AddHttpClient(Constants.LawnApiClientName, client =>
                {
                    client.BaseAddress = new Uri(_configuration.GetValue<string>(Constants.LawnApiHost));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LawnFile.API v1"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}