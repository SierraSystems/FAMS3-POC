using JobManager.SchedulerFactory;
using NUnit.Framework;
using Quartz;
using System.Threading.Tasks;

namespace JobManager.Test.Schedulers
{
    public class PersonToSearchScheduleFactoryTest
    {
        private IFAMSScheduleFactory _engine;
        [SetUp]
        public void Setup()
        {
            _engine = new FAMSScheduleFactory();
        }


        [Test]
        public void create_generic_trigger_instance()
        {
            var result = _engine.CreateScheduler();
            Assert.IsInstanceOf<Task<IScheduler>>(result);

        }

      

    }
}
