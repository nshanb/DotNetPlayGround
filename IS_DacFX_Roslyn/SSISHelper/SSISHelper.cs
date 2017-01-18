using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Runtime;

namespace SSISHelper
{
    public class Check
    {
        public static bool PackageFromProject(string packageName, string projectPath)
        {
            Project project = Project.OpenProject(projectPath);
            PackageItem pi = project.PackageItems.SingleOrDefault(x => x.Package.Name == packageName);
            return pi.Package!=null;
        }
    }
}
