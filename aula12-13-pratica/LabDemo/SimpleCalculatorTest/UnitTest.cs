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
            // prepare 
            // act
            double value = Operations.Sub(2, 1);
            // test
            Assert.AreEqual(1, value);
        }
    }
}
