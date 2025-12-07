using Framework.Helpers;
﻿using NUnit.Framework;
using Serilog;

namespace Framework.Tests
{
    [TestFixture]
    public class EducationTests : TestBase
    {
        [Test]
        [Retry(2)]
        public void HelloWorldTest()
        {
            Log.Information("Hello World!");
            Assert.That(1.Equals(2));
        }

        [Test]
        public void TestForStaticMethods()
        {
            DataHelpers dataHelpers = new DataHelpers();
            dataHelpers.GenerateString();
            DataHelpers.GenerateStringStatic();
        }
    }
}
