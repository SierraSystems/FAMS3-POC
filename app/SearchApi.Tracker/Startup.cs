using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SearchApi.Core.Options;
using System;
using System.IO;
using MassTransit.Saga;
using SearchApi.Core.Contracts;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();


            IConfiguration configuration = builder.Build();


            ConfigureServiceBus(services, configuration);

        }

        private static void ConfigureServiceBus(IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqSettings = configuration.GetSection(nameof(RabbitMq)).Get<RabbitMq>();
            var rabbitBaseUri = $"amqp://{rabbitMqSettings.Host}:{rabbitMqSettings.Port}";


            var repository = new InMemorySagaRepository<Investigation>();

            // Register Mass Transit
            services.AddMassTransit(x =>
            {
                // Add RabbitMq Service Bus
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {

                    var investigationStateMachine = new InvestigationStateMachine();

                    var host = cfg.Host(new Uri(rabbitBaseUri), hostConfigurator =>
                    {
                        hostConfigurator.Username(rabbitMqSettings.Username);
                        hostConfigurator.Password(rabbitMqSettings.Password);
                    });

                    cfg.ReceiveEndpoint(host, "investigation_state", e =>
                    { 
                        e.StateMachineSaga(investigationStateMachine, repository);
                    });

                }));
            });
        }
    }
}