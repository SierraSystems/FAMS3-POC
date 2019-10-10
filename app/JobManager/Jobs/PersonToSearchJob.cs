using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobManager.Jobs
{
    public class PersonToSearchJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Error.WriteLineAsync("Calling anything to do anything");
        }

   }

    public static class PersonToSearchJobDetail
    {
        public static  IJobDetail CreateJobDetail() => JobBuilder.Create<PersonToSearchJob>().WithIdentity(typeof(PersonToSearchJob).Assembly.GetName().Name,"FAMS3").Build();

    }


}
