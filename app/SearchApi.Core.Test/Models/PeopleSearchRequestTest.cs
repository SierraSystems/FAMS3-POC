using NUnit.Framework;
using SearchApi.Core.Models;

namespace SearchApi.Core.Test.Models
{
    public class PeopleSearchRequestTest
    {
        [Test]
        public void it_should_create_a_search_request()
        {
            var sut = new PeopleSearchRequest("firstName", "lastName", "email@example.com");
            Assert.AreEqual("firstName", sut.FirstName);
            Assert.AreEqual("lastName", sut.LastName);
            Assert.AreEqual("email@example.com", sut.Email);

        }

    }
}