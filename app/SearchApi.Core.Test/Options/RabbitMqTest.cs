using NUnit.Framework;
using SearchApi.Core.Options;

namespace SearchAPI.Test.Options
{
    public class RabbitMqTest
    {
        [Test]
        public void with_no_value_should_set_default_values()
        {
            var sut = new RabbitMq();
            Assert.AreEqual("localhost", sut.Host);
            Assert.AreEqual(5672, sut.Port);
            Assert.IsNull(sut.Username);
            Assert.IsNull(sut.Password);
        }

        [Test]
        public void with_host_set_should_get()
        {
            var sut = new RabbitMq();
            sut.Host = "foo";
            Assert.AreEqual("foo", sut.Host);
        }


        [Test]
        public void with_port_set_should_get()
        {
            var sut = new RabbitMq();
            sut.Port = 1234;
            Assert.AreEqual(1234, sut.Port);
        }

        [Test]
        public void with_password_set_should_get()
        {
            var sut = new RabbitMq();
            sut.Password = "foo";
            Assert.AreEqual("foo", sut.Password);
        }


        [Test]
        public void with_username_set_should_get()
        {
            var sut = new RabbitMq();
            sut.Username = "bar";
            Assert.AreEqual("bar", sut.Username);
        }

        

    }
}