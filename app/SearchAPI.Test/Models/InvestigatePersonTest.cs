using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Builders;
using SearchAPI.Models;

namespace SearchAPI.Test.Models
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