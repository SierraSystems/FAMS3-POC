using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobManager.Job
{
    public class PullPersonJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Error.WriteLineAsync("Calling Dynamics to get people data");
        }
    }
}
