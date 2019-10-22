using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Models;

namespace JobManager
{
    class Program
    {
        static  async Task  Main(string[] args)
        {

            Console.WriteLine("Starting Schedule Job API Tracker");

            var serviceCollection = new ServiceCollection();

            Startup.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var schedulerProvider = serviceProvider.GetService<IFAMSScheduleFactory>();
            var jobProvider = serviceProvider.GetService<IJobTrigger>();

            var scheduler = await  schedulerProvider.CreateScheduler();
            var trigger = jobProvider.CreateTrigger();

            var jobDetail = jobProvider.CreateJobDetail(new PeopleSearchRequest("John", "Doe", "john.doe@getme.com"));

            await scheduler.ScheduleJob(jobDetail, trigger);

             await scheduler.Start();

            Thread.Sleep(TimeSpan.FromMinutes(5));

            Console.WriteLine("Stopping Schedule Job API Tracker");

            await scheduler.Shutdown();
        }
    }
}
