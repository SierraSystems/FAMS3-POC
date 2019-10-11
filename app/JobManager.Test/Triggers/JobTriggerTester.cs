using JobManager.Triggers;
using JobManager.Jobs;
using Moq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace JobManager.Test.Triggers
{
    public class JobTriggerTester
    {

        private IJobTrigger<PersonToSearchJob> trigger;
     

        [SetUp]
        public void Setup()
        {
      
            trigger = new PersonToSearchTrigger<PersonToSearchJob>();
        }

        [Test]
        public void create_generic_trigger_instance()
        {
            var result = trigger.CreateTrigger();
            Assert.IsInstanceOf<ITrigger>(result);

        }

        [Test]
        public void create_trigger_cron_instance()
        {
            var result = trigger.CreateTrigger();
            Assert.IsInstanceOf<ICronTrigger>(result);

        }

        [Test]
        public void create_trigger_instance_with_name()
        {
            var result = trigger.CreateTrigger();
            Assert.AreEqual("PersonToSearchJob-Trigger", result.Key.Name);

        }

        [Test]
        public void create_trigger_instance_with_group()
        {
            var result = trigger.CreateTrigger();
            Assert.AreEqual("FAMS3", result.Key.Group);

        }
    }
}
