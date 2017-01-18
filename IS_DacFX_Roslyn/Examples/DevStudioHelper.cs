using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class DevStudioHelper
    {
        public static string SSISprojectPath
        {
            get
            {
                return Path.Combine(Directory.GetParent(RoslynHelper.T4Helper.TemplateDir).ToString(), "SSIS");
            }
        }
        public static string TestDBprojectPath
        {
            get
            {
                return Path.Combine(Directory.GetParent(RoslynHelper.T4Helper.TemplateDir).ToString(), "TestDB");
            }
        }
    }
}
