using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
    [TestClass]
    public class EvalTests
    {
        [TestMethod]
        public void EvalSimpleInt()
        {
            Assert.AreEqual(2, RoslynHelper.RunTime.EvalInt("1+1"));
            Assert.AreEqual(2, RoslynHelper.RunTime.EvalInt("int i; int j; i=1; return i+1;"));
            Assert.AreEqual(2, RoslynHelper.RunTime.EvalInt("int i; int j; i=1; i+1"));
        }
        [TestMethod]
        public void TestProjectDir()
        {
            RoslynHelper.DesignTime.ProjectDIr();
        }
    }
}
