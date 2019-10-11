using JobManager.SchedulerFactory;
using NUnit.Framework;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobManager.Test.Schedulers
{
    public class PersonToSearchScheduleFactoryTest
    {
        private IFAMSScheduleFactory engine;
        [SetUp]
        public void Setup()
        {
            engine = new FAMSScheduleFactory();
        }


        [Test]
        public void create_generic_trigger_instance()
        {
            var result = engine.CreateScheduler();
            Assert.IsInstanceOf<Task<IScheduler>>(result);

        }

      

    }
}
