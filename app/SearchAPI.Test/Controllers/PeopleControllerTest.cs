using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SearchAPI.Controllers;
using SearchAPI.Models;

namespace SearchAPI.Test.Controllers
{
    public class PeopleControllerTest
    {

        private PeopleController sut;

        private Mock<IBus> _busMock;

        [SetUp] 
        public void init()
        {
            EndpointConvention.Map<InvestigatePerson>(new Uri("rabbitmq://somehost/someroute"));
            this._busMock = new Mock<IBus>();
            sut = new PeopleController(_busMock.Object);
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