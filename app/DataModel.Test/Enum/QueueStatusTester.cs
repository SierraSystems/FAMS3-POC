using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Enum;
using NUnit.Framework;

namespace DataModel.Test.Enum
{
    public class QueueStatusTester
    {
        [Test]
        public void Should_Return_For_Search ()
        {
            Assert.AreEqual("ReadyForSearch", QueueStatus.ReadyForSearch.GetName());
        }
    }
}
