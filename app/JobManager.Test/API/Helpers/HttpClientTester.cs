﻿using JobManager.API.Helpers;
using NUnit.Framework;

namespace JobManager.Test.API.Helpers
{
    public  class HttpClientTester
    {

        private HttpClient _sut;
   

        [SetUp]
        public void Setup ()
        {
            _sut = new HttpClient();



        }
        [Test]
        public void check_create_is_not_null()
        {
            Assert.IsInstanceOf<HttpClient>(_sut);
        }
    }

    
}
