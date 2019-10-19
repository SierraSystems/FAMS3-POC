using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JobManager.API.Services;

namespace JobManager.Jobs
{
    [DisallowConcurrentExecution]
    public class PersonToSearchJob : IJob
    {

        private readonly ISearchService _searchService;
   

        public PersonToSearchJob(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
          
           var response =  await _searchService.InitiateSearch();
            await Console.Out.WriteLineAsync(response.SearchRequestId.ToString());

        }
    }

    public static class PersonToSearchJobDetail
    {
        public static  IJobDetail CreateJobDetail() => JobBuilder.Create<PersonToSearchJob>().WithIdentity(typeof(PersonToSearchJob).Name, "FAMS3").Build();

    }
}
