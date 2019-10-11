using System;
using NUnit.Framework;
using SearchApi.Core.Contracts;

namespace SearchApi.Core.Test.Contracts
{
    public class InvestigatePersonTest
    {
        [Test]
        public void should_return_an_instence_of_InvestigatePerson()
        {
            var sut = InvestigatePerson.Create();
            Assert.AreNotEqual(default(Guid), sut.OrderId);
        }
    }
}