using System;
using System.Threading.Tasks;
using DataModel.Models;
using JobManager.API.Helpers;
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
        private PeopleSearchRequest _request;

            [SetUp]
        public void Setup()
        {
            _client = new Mock<HttpClient>();
            _request = new PeopleSearchRequest("Ranti", "Familusi", "familusi.babaranti@gmail.com");
         
            _client.Setup(x => x.Post<PeopleSearchResponse>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PeopleSearchRequest>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<object>(), It.IsAny<object>())).Returns(Task.FromResult( PeopleSearchResponse.Create(Guid.NewGuid())));
            _sut = new SearchService(_client.Object,_baseUrl,_path);
        }

        [Test]
        public void initiate_search_returns_accepted()
        {
            var response = _sut.InitiateSearch(_request); 
            Assert.IsInstanceOf<PeopleSearchResponse>(response.Result);
        }
    }
}
