using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
    [TestClass]
    public class EvalTests
    {
        [TestMethod]
        public void SimpleInt()
        {
            Assert.AreEqual(2, RoslynHelper.RunTime.EvalInt("1+1"));
        }
    }
}
