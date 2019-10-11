using JobManager.SchedulerFactory;
using Quartz;
using System;
using System.Threading.Tasks;

namespace JobManager
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            IScheduler sched = await new FAMSScheduleFactory().CreateScheduler();
           await  sched.Start();

            Console.WriteLine("Hello World!");
        }
    }
}
