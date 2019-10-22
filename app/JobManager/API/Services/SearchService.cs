

using System.Threading.Tasks;
using DataModel.Models;
using JobManager.API.Helpers;

namespace JobManager.API.Services
{
   public class SearchService : ISearchService
   {
       private readonly FAMSHttpClient _client;
       private readonly string _baseUrl;
       private readonly string _path;

       public SearchService(FAMSHttpClient client, string baseUrl, string path)
       {
           _client = client;
           _baseUrl = baseUrl;
           _path = path;
       }


       public Task<PeopleSearchResponse> InitiateSearch()
        {
            return _client.Post<PeopleSearchResponse>(_baseUrl, _path);
        }
    }

   public interface ISearchService
   {
       Task<PeopleSearchResponse> InitiateSearch();
   }
}
