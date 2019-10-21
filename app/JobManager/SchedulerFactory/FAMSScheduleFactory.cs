using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace JobManager.SchedulerFactory
{
    public  class FAMSScheduleFactory : IFAMSScheduleFactory
    {
        public  async Task <IScheduler> CreateScheduler()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            return  await factory.GetScheduler();
        }
    }

    public interface IFAMSScheduleFactory
    {
        Task<IScheduler> CreateScheduler();
    }
}
