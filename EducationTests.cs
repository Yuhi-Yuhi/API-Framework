using Framework.Helpers;
﻿using NUnit.Framework;
using Serilog;

namespace Framework
{
    [TestFixture]
    public class EducationTests : TestBase
    {
        [Test]
        public void HelloWorldTest()
        {
            Log.Information("Hello World!");
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
