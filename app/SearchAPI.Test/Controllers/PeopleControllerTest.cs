using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SearchAPI.Controllers;
using SearchAPI.Models;

namespace SearchAPI.Test.Controllers
{
    public class PeopleControllerTest
    {

        private PeopleController sut;

        private Mock<ISendEndpoint> _sendEndpointMock;

        private Mock<ISendEndpointProvider> _sendEndPointProviderMock;


        [SetUp] 
        public void init()
        {
            EndpointConvention.Map<InvestigatePerson>(new Uri("http://random"));

            _sendEndpointMock = new Mock<ISendEndpoint>();

            _sendEndPointProviderMock = new Mock<ISendEndpointProvider>();
            _sendEndPointProviderMock.Setup(x => x.GetSendEndpoint(It.IsAny<Uri>())).Returns(Task.FromResult(_sendEndpointMock.Object));

            sut = new PeopleController(_sendEndPointProviderMock.Object);
        }

        [Test]
        public void with_valid_request_should_accept_request()
        {
            var result = (AcceptedResult) sut.Search().Result;
            _sendEndpointMock.Verify(x => x.Send(It.IsAny<InvestigatePerson>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsInstanceOf<PeopleSearchResponse>(result.Value);
            Assert.IsNotNull(((PeopleSearchResponse)result.Value).SearchRequestId);
        }



    }
}