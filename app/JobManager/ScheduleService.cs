using JobManager.Jobs;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobManager
{
    public class ScheduleService : IScheduleService
    {
        private readonly IFAMSScheduleFactory factory;
        private readonly IJobTrigger<PersonToSearchJob> trigger;
        public ScheduleService (IFAMSScheduleFactory _factory, IJobTrigger<PersonToSearchJob> _trigger )
        {
            factory = _factory;
            trigger = _trigger;
        }
        public async void Start()
        {
            var sched = await factory.CreateScheduler();
            await sched.Start();

            await sched.ScheduleJob(PersonToSearchJobDetail.CreateJobDetail(),trigger.CreateTrigger());

        }
    }

    public interface IScheduleService
    {
        void Start();
    }
}
