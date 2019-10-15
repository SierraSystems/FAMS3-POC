using JobManager.SchedulerFactory;
using Quartz;
using System;
using System.Threading.Tasks;
using JobManager.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobManager
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
