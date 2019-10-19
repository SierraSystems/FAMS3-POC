using System;
using System.Threading.Tasks;
using JobManager.API.Helpers;
using JobManager.API.Models;
using JobManager.API.Services;
using Moq;
using NUnit.Framework;

namespace JobManager.Test.API.Services
{
    public class SearchServiceTester
    {

        private SearchService _sut;
        private Mock<PeopleSearchResponse> _people;
        private Mock<HttpClient> _client;
        private readonly string _baseUrl = "http://localhost:6341/";
        private readonly string _path = "Search";

        [SetUp]
        public void Setup()
        {
            _client = new Mock<HttpClient>();
            _client.Setup(x => x.Post<PeopleSearchResponse>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<object>(), It.IsAny<object>())).Returns(Task.FromResult( PeopleSearchResponse.Create(Guid.NewGuid())));
            _sut = new SearchService(_client.Object,_baseUrl,_path);
        }

        [Test]
        public void initiate_search_returns_accepted()
        {
            var response = _sut.InitiateSearch(); 
            Assert.IsInstanceOf<PeopleSearchResponse>(response.Result);
        }
    }
}
