using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

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
            var jobProvider = serviceProvider.GetService<IJobTrigger>();
           

        
            var scheduler = await schedulerProvider.CreateScheduler();

         
            var trigger = jobProvider.CreateTrigger();
            var jobdetail = jobProvider.CreateJobDetail();
            
         


            await scheduler.ScheduleJob(jobdetail, trigger);

            await scheduler.Start();

            Console.ReadKey();
        }
    }
}
