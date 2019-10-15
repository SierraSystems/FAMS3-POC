using JobManager.Jobs;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobManager
{
    public class ScheduleService : IScheduleService
    {
        private readonly IFAMSScheduleFactory factory;
        private static  IScheduler _schedulerService;
        private readonly IJobTrigger<PersonToSearchJob> trigger;
        public ScheduleService(IFAMSScheduleFactory _factory, IJobTrigger<PersonToSearchJob> _trigger, IScheduler SchedulerService)
        {
            factory = _factory;
            trigger = _trigger;
            _schedulerService =  factory.CreateScheduler().Result;
        }
        //TODO : Refactor
        public async void Start()
        {
            while (!_schedulerService.IsStarted)
                await _schedulerService.Start();
        }

        public IScheduler SchedulerService { get { return _schedulerService; } }
        
        public async Task<DateTimeOffset> Schedule()
        {
           return  await _schedulerService.ScheduleJob(PersonToSearchJobDetail.CreateJobDetail(), trigger.CreateTrigger());
        }
        public async void Stop()
        {
            while (!_schedulerService.IsShutdown)
               await _schedulerService.Shutdown();
        }
    }
    public interface IScheduleService
    {
        void Start();

        Task<DateTimeOffset> Schedule();

        void Stop();
    }
}
