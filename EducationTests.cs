using Framework.Helpers;
﻿using NUnit.Framework;

namespace Framework
{
    [TestFixture]
    public class EducationTests
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("Hello World!");
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
