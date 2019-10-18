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
using SearchApi.Core.Contracts.PersonSearch;
using SearchApi.Core.Models;
using SearchAPI.Models;

namespace SearchAPI.Test.Controllers
{
    public class PeopleControllerTest
    {

        private PeopleController sut;

        private readonly Mock<IBusControl> _iBusControl = new Mock<IBusControl>();


        [SetUp] 
        public void init()
        {
            _iBusControl.Setup(x => x.Publish(It.IsAny<SearchRequested>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            sut = new PeopleController(_iBusControl.Object);
        }

        [Test]
        public void with_valid_request_should_accept_request()
        {
            var result = (AcceptedResult) sut.Search(new PeopleSearchRequest("test", "test", "test@example.com")).Result;
            _iBusControl.Verify(x => x.Publish(It.IsAny<SearchRequested>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsInstanceOf<PeopleSearchResponse>(result.Value);
            Assert.IsNotNull(((PeopleSearchResponse)result.Value).SearchRequestId);
        }



    }
}