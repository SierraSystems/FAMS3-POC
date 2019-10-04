using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SearchAPI.Controllers;

namespace SearchAPI.Test.Controllers
{

    public  class ValuesControllerTest
    {
        private ValuesController sut;

        [SetUp]
        public void Setup()
        {
            sut = new ValuesController();
        }

        [Test]
        public void Get_should_return_values()
        {
            var result = (OkObjectResult)sut.Get().Result;
            Assert.IsInstanceOf<IEnumerable<string>>(result.Value);
            Assert.AreEqual(2, ((IEnumerable<string>)result.Value).Count());
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-100)]
        public void Get_by_id_should_return_value(int id)
        {
            var result = (OkObjectResult)sut.Get(1).Result;
            Assert.IsInstanceOf<string>(result.Value);
            Assert.AreEqual("value", result.Value.ToString());
        }

    }
}
