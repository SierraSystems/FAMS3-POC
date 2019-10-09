using NUnit.Framework;
using SearchAPI.Controllers;
using SearchAPI.Models;

namespace SearchAPI.Test.Models
{
    public class PeopleSearchResponseTest
    {

        [Test]
        public void should_create_request()
        {
            var response = PeopleSearchResponse.Create();
            Assert.IsNotNull(response.SearchRequestId);
        }


    }
}