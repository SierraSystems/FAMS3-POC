using JobManager.Configuration;
using JobManager.SchedulerFactory;
using JobManager.Triggers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;

namespace JobManager.Test.Configuration
{
    public class ConfigureServicesModuleTester
    {
        [Test]
        public void should_register_the_necessary_services()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServicesModule.ConfigureServices(services: serviceCollection);

            Assert.IsTrue(serviceCollection.Any(x => x.ServiceType == typeof(IFAMSScheduleFactory)));

            Assert.IsTrue(serviceCollection.Any(x => x.ServiceType == typeof(IJobTrigger)));


        }
    }
}
