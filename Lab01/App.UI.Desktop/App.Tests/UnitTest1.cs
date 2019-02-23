using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumasEsOK()
        {
            Assert.IsTrue(4+5==9);
        }
    }
}
