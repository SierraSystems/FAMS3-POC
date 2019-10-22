using JobManager.API.Helpers;
using NUnit.Framework;

namespace JobManager.Test.API.Helpers
{
    public  class HttpClientTester
    {

        private FAMSHttpClient _sut;
   

        [SetUp]
        public void Setup ()
        {
            _sut = new FAMSHttpClient();



        }
        [Test]
        public void check_create_is_not_null()
        {
            Assert.IsInstanceOf<FAMSHttpClient>(_sut);
        }
    }

    
}
