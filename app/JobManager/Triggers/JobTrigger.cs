using System;
using JobManager.Jobs;
using Quartz;

namespace JobManager.Triggers
{
    public class PersonToSearchTrigger<T> : IJobTrigger
    {
        public ITrigger CreateTrigger()
        {
            Console.WriteLine("initiating trigger");
            return TriggerBuilder.Create()
                .WithIdentity(string.Concat(typeof(T).Name,"-Trigger"), "FAMS3")
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(10).WithRepeatCount(1))
                .Build();
        }


        public IJobDetail CreateJobDetail(object data)
        {
            var jobdetail = JobBuilder.Create<PersonToSearchJob>().WithIdentity(typeof(PersonToSearchJob).Name, "FAMS3").Build();
            jobdetail.JobDataMap.Put("person", data);
            return jobdetail;
        }
    }

    public interface IJobTrigger
    {
        ITrigger CreateTrigger();
        IJobDetail CreateJobDetail(object data);
    }
}
