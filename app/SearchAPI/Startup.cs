using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchApi.Core.Contracts;
using SearchApi.Core.Options;

namespace SearchAPI
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
            services
                .AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddHealthChecks();

            // Register NSwag services
            services.AddSwaggerDocument(config =>
            {
                // configure swagger properties
                config.PostProcess = document =>
                {
                    document.Info.Version = "V0";
                    document.Info.Description = "For Search";
                    document.Info.Title = AppDomain.CurrentDomain.FriendlyName;
                };
            });

            ConfigureServiceBus(services);
        }

        private void ConfigureServiceBus(IServiceCollection services)
        {
            var rabbitMqSettings = Configuration.GetSection(nameof(RabbitMq)).Get<RabbitMq>();
            var rabbitBaseUri = $"amqp://{rabbitMqSettings.Host}:{rabbitMqSettings.Port}";

            // Register Mass Transit
            services.AddMassTransit(x =>
            {
                // Add RabbitMq Service Bus
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitBaseUri), hostConfigurator =>
                    {
                        hostConfigurator.Username(rabbitMqSettings.Username);
                        hostConfigurator.Password(rabbitMqSettings.Password);
                    });
                }));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseHealthChecks("/health");

            // Register the swagger generator middleware
            app.UseOpenApi();

        }
    }
}
