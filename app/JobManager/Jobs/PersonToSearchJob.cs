using Quartz;
using System;
using System.Threading.Tasks;
using DataModel.Models;
using JobManager.API.Services;

namespace JobManager.Jobs
{
   
    public class PersonToSearchJob : IJob
    {

       
        public async Task Execute(IJobExecutionContext context)
        {
            var _request = (PeopleSearchRequest)context.JobDetail.JobDataMap.Get("person");
            Console.WriteLine("back from dynamics - well not exactly - with records " + _request.Email);
            Console.WriteLine("sending for search - for real " + _request.Email);
            //var response =  await _searchService.InitiateSearch(_request);
            //Console.WriteLine("back from  search - for real " + _request.Email);
            //await Console.Out.WriteLineAsync(response.SearchRequestId.ToString());

        }
    }

    public static class PersonToSearchJobDetail
    {
        public static  IJobDetail CreateJobDetail() => JobBuilder.Create<PersonToSearchJob>().WithIdentity(typeof(PersonToSearchJob).Name, "FAMS3").Build();

    }
}
