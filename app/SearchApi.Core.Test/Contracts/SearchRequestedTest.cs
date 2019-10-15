using System;
using NUnit.Framework;
using SearchApi.Core.Contracts;
using SearchApi.Core.Contracts.PersonSearch;

namespace SearchApi.Core.Test.Contracts
{
    public class SearchRequestedTest
    {
        [Test]
        public void should_return_an_instence_of_InvestigatePerson()
        {
            var sut = SearchRequested.Create();
            Assert.AreNotEqual(default(Guid), sut.CorrelationId);
        }
    }
}