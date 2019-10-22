using NUnit.Framework;
using Quartz;
using JobManager.Jobs;

namespace JobManager.Test.Jobs
{
    public class PersonToSearchJobTester
    {
    

        [SetUp]
        public void Setup()
        {

     }

        [Test]
        public void create_job_detail()
        {
            var result = PersonToSearchJobDetail.CreateJobDetail();

            Assert.IsInstanceOf<IJobDetail>(result);
        }

        [Test]
        public void create_job_detail_key_name_of_job_class()
        {
            var result = PersonToSearchJobDetail.CreateJobDetail();

            Assert.AreEqual(result.Key.Name, "PersonToSearchJob");
        }

        [Test]
        public void create_job_detail_key_group_fams3()
        {
            var result = PersonToSearchJobDetail.CreateJobDetail();

            Assert.AreEqual(result.Key.Group, "FAMS3");
        }

    }
}
