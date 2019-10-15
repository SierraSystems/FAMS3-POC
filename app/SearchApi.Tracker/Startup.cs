using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SearchApi.Core.Options;
using System;
using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.EntityFrameworkCoreIntegration.Saga;
using MassTransit.Saga;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SearchApi.Tracker.Db;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker
{
    public class Startup
    {
        public static IServiceProvider CreateServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            Startup.ConfigureServices(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();


            IConfiguration configuration = builder.Build();

            ConfigureDbContext(services, configuration);

            ConfigureServiceBus(services, configuration);

        }

        public static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<StateMachineContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("StateMachineContext")),
                    ServiceLifetime.Singleton, 
                    ServiceLifetime.Singleton);
        }

        private static void ConfigureServiceBus(IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqSettings = configuration.GetSection(nameof(RabbitMq)).Get<RabbitMq>();
            var rabbitBaseUri = $"amqp://{rabbitMqSettings.Host}:{rabbitMqSettings.Port}";

            var factory = new Factory();
            ISagaDbContextFactory<Investigation> contextFactory = new DelegateSagaDbContextFactory<Investigation>(() => factory.CreateDbContext(Array.Empty<string>()));
            var repository = new EntityFrameworkSagaRepository<Investigation>(contextFactory);

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


        private class Factory : IDesignTimeDbContextFactory<StateMachineContext>
        {
            public StateMachineContext CreateDbContext(string[] args)
                => CreateServiceProvider().GetService<StateMachineContext>();
        }
    }
}