using System;
using System.Collections.Generic;
using System.Text;
using JobManager.Jobs;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Microsoft.Extensions.DependencyInjection;

namespace JobManager.Configuration
{
    public class ConfigureServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFAMSScheduleFactory, FAMSScheduleFactory>();
            services.AddTransient<IJobTrigger<PersonToSearchJob>, PersonToSearchTrigger<PersonToSearchJob>>();
        }
    }
}
