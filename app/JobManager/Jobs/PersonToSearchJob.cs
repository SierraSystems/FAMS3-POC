using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JobManager.Jobs
{
    [DisallowConcurrentExecution]
    public class PersonToSearchJob : IJob
    {
        private readonly IPersonToSearch personToFind = new PersonToSearch();

        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync(personToFind.Get().Count.ToString());

        }
    }

    public static class PersonToSearchJobDetail
    {
        public static  IJobDetail CreateJobDetail() => JobBuilder.Create<PersonToSearchJob>().WithIdentity(typeof(PersonToSearchJob).Name, "FAMS3").Build();

    }
}
