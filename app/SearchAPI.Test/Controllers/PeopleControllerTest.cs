using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SearchAPI.Controllers;
using SearchAPI.Models;

namespace SearchAPI.Test.Controllers
{
    public class PeopleControllerTest
    {

        private PeopleController sut;

        [SetUp] 
        public void init()
        {
            sut = new PeopleController();
        }

        [Test]
        public void with_valid_request_should_accept_request()
        {
            var result = (AcceptedResult) sut.Search().Result;
            Assert.IsInstanceOf<PeopleSearchResponse>(result.Value);
            Assert.IsNotNull(((PeopleSearchResponse)result.Value).SearchRequestId);
        }



    }
}