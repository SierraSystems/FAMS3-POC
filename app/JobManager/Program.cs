using JobManager.Jobs;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using JobManager.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobManager
{

  
    class Program
    {
        static async Task  Main(string[] args)
        {

            Console.WriteLine("Starting Schedule Job API Tracker");

            var serviceCollection = new ServiceCollection();

            Startup.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var schedulerProvider = serviceProvider.GetService<IFAMSScheduleFactory>();
            var jobProvider = serviceProvider.GetService<IJobTrigger<PersonToSearchJob>>();
           

        
            var scheduler = await schedulerProvider.CreateScheduler();

         
            var trigger = jobProvider.CreateTrigger();
            var jobdetail = jobProvider.CreateJobDetail();

         


            await scheduler.ScheduleJob(jobdetail, trigger);

            await scheduler.Start();

            Console.ReadKey();
        }
    }
}
