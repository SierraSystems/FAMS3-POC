using JobManager.Job;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobManager.Trigger
{
    public class JobTrigger<T>
    {
        public ITrigger CreateTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity(typeof(T).Assembly.GetName().Name, "FAMS3")
                .WithCronSchedule("0 0/2 * * * ?")
                .Build();
        }


      
    }
}
