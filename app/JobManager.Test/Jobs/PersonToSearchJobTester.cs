using Moq;
using NUnit.Framework;
using Quartz;
using JobManager.Jobs;
using System.Threading.Tasks;

namespace JobManager.Test.Jobs
{
    public class PersonToSearchJobTester
    {
        private Mock<IJobDetail> jobdetail;
        private Mock<PersonToSearchJob> personjob;
        private Mock<IJobExecutionContext> jobcontext;
        string  ExecuteResult = "Please find me dynamics";

        [SetUp]
        public void Setup()
        {
            personjob = new Mock<PersonToSearchJob>();
            jobdetail = new Mock<IJobDetail>();

            jobcontext = new Mock<IJobExecutionContext>();

            personjob.Setup(x => x.Execute(It.IsAny<IJobExecutionContext>())).Returns(Task.FromResult(ExecuteResult));

        }

        [Test]
        public void create_job_detail()
        {
            var result = PersonToSearchJobDetail.CreateJobDetail();

            Assert.IsInstanceOf<IJobDetail>(result);
        }

      
    }
}
