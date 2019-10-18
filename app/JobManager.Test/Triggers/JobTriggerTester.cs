using JobManager.Triggers;
using JobManager.Jobs;
using Quartz;
using NUnit.Framework;

namespace JobManager.Test.Triggers
{
    public class JobTriggerTester
    {

        private IJobTrigger<PersonToSearchJob> _trigger;
     

        [SetUp]
        public void Setup()
        {
      
            _trigger = new PersonToSearchTrigger<PersonToSearchJob>();
        }

        [Test]
        public void create_generic_trigger_instance()
        {
            var result = _trigger.CreateTrigger();
            Assert.IsInstanceOf<ITrigger>(result);

        }

        [Test]
        public void create_trigger_cron_instance()
        {
            var result = _trigger.CreateTrigger();
            Assert.IsInstanceOf<ICronTrigger>(result);

        }

        [Test]
        public void create_trigger_instance_with_name()
        {
            var result = _trigger.CreateTrigger();
            Assert.AreEqual("PersonToSearchJob-Trigger", result.Key.Name);

        }

        [Test]
        public void create_trigger_instance_with_group()
        {
            var result = _trigger.CreateTrigger();
            Assert.AreEqual("FAMS3", result.Key.Group);

        }
    }
}
