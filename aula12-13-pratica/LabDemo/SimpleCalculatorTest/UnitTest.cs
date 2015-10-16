using System;
using SimpleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculatorTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodAdd()
        {
            Assert.AreEqual(2, Operations.Add(1, 1));
        }

        [TestMethod]
        public void TestMethodSub()
        {
            Assert.AreEqual(1, Operations.Sub(2, 1));
        }
    }
}
