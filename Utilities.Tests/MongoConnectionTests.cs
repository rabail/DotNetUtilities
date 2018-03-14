using DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Tests
{
    [TestFixture]
    class MongoConnectionTests
    {
        string mongoConnectionString;

        [SetUp]
        public void SetUp()
        {
            mongoConnectionString = "mongodb://localhost:27017/Rabail?ssl=true";
        }

        [Test]
        public void ShouldConnectToMongoDB()
        {
            MongoDBDataAccess dbHandle = new MongoDBDataAccess(mongoConnectionString, @"C:\WebHost\mongodb.pfx", "123456");
            var handle = dbHandle.GetDatabaseHandle();
            Assert.IsNotNull(handle);
        }


    }
}
