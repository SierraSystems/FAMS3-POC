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
                .WithCronSchedule("0 0/2 * * * ?")
                .Build();
        }


      
    }

    public interface IJobTrigger<T>
    {
        ITrigger CreateTrigger();
    }
}
