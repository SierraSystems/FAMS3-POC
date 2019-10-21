using System;
using NUnit.Framework;
using SearchApi.Core.Providers;

namespace SearchApi.Core.Test.Providers
{
    public class ProviderTest
    {

        [Test]
        public void it_should_create_a_provider()
        {
            var sut = new Provider()
            {
                Name = "Test"
            };
            Assert.AreEqual("Test", sut.Name);
        }

    }
}