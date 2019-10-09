using DataModel.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Test.Enum
{
    public class ResultTypeTester
    {


        [Test]
        public void Should_Return_For_Search()
        {
            Assert.AreEqual("Address", ResultTypes.Address.GetName());
        }
    }
}
