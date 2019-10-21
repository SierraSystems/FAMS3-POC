using System;
using NUnit.Framework;
using SearchApi.Core.Contracts;
using SearchApi.Core.Contracts.PersonSearch;
using SearchApi.Core.Models;

namespace SearchApi.Core.Test.Contracts
{
    public class SearchRequestedTest
    {
        [Test]
        public void should_return_an_instence_of_InvestigatePerson()
        {
            var sut = SearchRequested.Create(new PeopleSearchRequest("test", "test", "test"));
            Assert.AreNotEqual(default(Guid), sut.CorrelationId);
        }
    }
}