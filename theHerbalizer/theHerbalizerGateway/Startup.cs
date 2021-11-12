using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net.Http;
using theHerbalizerGateway.Services;

namespace theHerbalizerGateway
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "theHerbalizerGateway", Version = "v1" });
            });

            services.AddSingleton<ILawnFileService, LawnFileService>();
            services
               .AddHttpClient("Default")
                   .ConfigurePrimaryHttpMessageHandler(() =>
                   {
                       return new HttpClientHandler
                       {
                           AllowAutoRedirect = false,
                           UseDefaultCredentials = true,
                       };
                   });

                   //.AddTransientHttpErrorPolicy((policy) => policy.WaitAndRetryAsync(
                   //    HTTP_ERROR_RETRY_NUMBER,
                   //    (retryCount) => TimeSpan.FromMilliseconds(retryCount * HTTP_ERROR_MILLISECOND_BETWEEN_RETRY)))
                   //.AddTransientHttpErrorPolicy((policy) => policy.CircuitBreakerAsync(HTTP_ERROR_NUMBER_BEFORE_BREAK, TimeSpan.FromSeconds(HTTP_ERROR_BREAK_DURATION)));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "theHerbalizerGateway v1"));
            }

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