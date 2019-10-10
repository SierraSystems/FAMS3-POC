using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SearchAPI.Models;
using SearchAPI.Options;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            var rabbitMqSettings = Configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>();

            // Register Mass Transit
            services.AddMassTransit(x =>
            {
                // Add RabbitMq Service Bus
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri($"amqp://{rabbitMqSettings.Host}:{rabbitMqSettings.Port}/"), hostConfigurator =>
                    {
                        hostConfigurator.Username(rabbitMqSettings.Username);
                        hostConfigurator.Password(rabbitMqSettings.Password);
                    });
                }));
            });

            // Add specific endpoint to route Investigate Person orders
            EndpointConvention.Map<InvestigatePerson>(new Uri($"amqp://{rabbitMqSettings.Host}:{rabbitMqSettings.Port}/{nameof(InvestigatePerson)}"));

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
