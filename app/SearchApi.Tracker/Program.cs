using MassTransit;
using System;
using MassTransit.Util;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace SearchApi.Tracker
{
    class Program
    {

        private static BusHandle _busHandle;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceCollection = new ServiceCollection();

            Startup.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();


            var bus = serviceProvider.GetService<IBusControl>();
            _busHandle = TaskUtil.Await(() => bus.StartAsync());

        }

    }
}
