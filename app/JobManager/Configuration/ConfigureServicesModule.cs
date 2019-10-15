using System;
using System.Collections.Generic;
using System.Text;
using JobManager.Jobs;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobManager.Configuration
{
    public class ConfigureServicesModule
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddTransient<IFAMSScheduleFactory, FAMSScheduleFactory>();
            services.AddTransient<IJobTrigger<PersonToSearchJob>, PersonToSearchTrigger<PersonToSearchJob>>();
        }
    }
}
