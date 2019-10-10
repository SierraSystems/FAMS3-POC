using JobManager.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobManager.Triggers
{
    public class JobTrigger<T>
    {
        public ITrigger CreateTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity(string.Concat(typeof(T).Assembly.GetName().Name,"-Trigger"), "FAMS3")
                .WithCronSchedule("0 0/2 * * * ?")
                .Build();
        }


      
    }
}
