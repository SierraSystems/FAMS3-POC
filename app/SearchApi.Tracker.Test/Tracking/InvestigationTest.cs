using System;
using NUnit.Framework;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker.Test.Tracking
{
    public class InvestigationTest
    {
        [Test]
        public void Should_create_an_integration()
        {
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var sut = new Investigation();
            sut.SearchRequestId = id;
            sut.CurrentState = "CurrentState";
            sut.CorrelationId = id2;

            Assert.AreEqual(id, sut.SearchRequestId);
            Assert.AreEqual(id2, sut.CorrelationId);
            Assert.AreEqual("CurrentState", sut.CurrentState);

        }
    }
}