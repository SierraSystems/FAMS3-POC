using JobManager.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobManager.Triggers
{
    public class PersonToSearchTrigger<T> : IJobTrigger<T>
    {
        public ITrigger CreateTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity(string.Concat(typeof(T).Name,"-Trigger"), "FAMS3")
                .WithCronSchedule("0 0/1 * * * ?")
                .Build();
        }

        public  IJobDetail CreateJobDetail() => JobBuilder.Create<PersonToSearchJob>().WithIdentity(typeof(PersonToSearchJob).Name, "FAMS3").Build();


    }

    public interface IJobTrigger<T>
    {
        ITrigger CreateTrigger();
        IJobDetail CreateJobDetail();
    }
}
