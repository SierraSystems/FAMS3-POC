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
        public async Task<bool>  Start()
        {
            var _schedulerService = await factory.CreateScheduler();
            await _schedulerService.Start();

            await _schedulerService.ScheduleJob(PersonToSearchJobDetail.CreateJobDetail(),trigger.CreateTrigger());
            return _schedulerService.IsStarted;

        }
    }

    public interface IScheduleService
    {
        Task<bool> Start();
    }
}
