using MassTransit;
using System;
using MassTransit.Util;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SearchApi.Tracker.Db;

namespace SearchApi.Tracker
{
    class Program
    {

        private static BusHandle _busHandle;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Search API Tracker");

            var serviceProvider = Startup.CreateServiceProvider();

            var bus = serviceProvider.GetService<IBusControl>();
            
            _busHandle = TaskUtil.Await(() => bus.StartAsync());

        }
    }
}
