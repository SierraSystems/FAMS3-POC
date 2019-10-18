using NUnit.Framework;
using System;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using JobManager.Jobs;
using Quartz;

namespace JobManager.Test
{
    public class ScheduleServiceTester
    {

        private ScheduleService _service;
        private IFAMSScheduleFactory _factory;
        private readonly IScheduler _schedulerService;
        private IJobTrigger<PersonToSearchJob> _trigger;

        [SetUp]
        public void Setup()
        {
            _factory = new FAMSScheduleFactory();
            _trigger = new PersonToSearchTrigger<PersonToSearchJob>();
            _service = new ScheduleService(_factory, _trigger, _schedulerService);
        }
        [Test]
        public void start_schedule_service()
        {
            var scheduleDateTimeOffset = _service.Schedule();
            _service.Start();
            _service.Stop();
                
            Assert.AreEqual(true, _service.SchedulerService.IsStarted);
        }
        [Test]
        public void initiate_schedule_service()
        {
         
      
            var result = _service.Schedule();
            Assert.IsInstanceOf<DateTimeOffset>( result.Result) ;
        }

        [Test]
        public void stop_schedule_service()
        {
            _service.Start();
            _service.Stop();
            Assert.AreEqual(true, _service.SchedulerService.IsShutdown);
        }
    }
}
