using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SSISHelper;

namespace Examples
{
    [TestClass]
    public class SSISTests
    {
        [TestMethod]
        public void EnumService()
        {
            List<string> l;
            l = Check.EnumService();
            foreach(string s in l)
            {
                Console.WriteLine(s);
            }
        }
    }
}
