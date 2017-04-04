using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.IntegrationServices;
using System.Data.SqlClient;

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
        public static List<string> EnumPackages(int type)
        {
            List<string> list = new List<string>();
            Application ssisApp = new Application();
            //PackageInfos sqlPackages = null;
            
            //ssisApp.CreateFolderOnSqlServer("\\", "kaka", "(local)", "sa", "1");
            //ssisApp.CreateFolderOnDtsServer(@"\", "kaka", "PC-0609");
            // aaaaaaa  all of this works with MSDB!!!
            switch (type)
            {
                case 1:
                    //sqlPackages = ssisApp.GetDtsServerPackageInfos("MSDB", ".");
                    //sqlPackages = ssisApp.GetDtsServerPackageInfos("MSDB", "(local)");
                   // sqlPackages = ssisApp.GetDtsServerPackageInfos("MSDB", "PC-0609");
                    break;
                case 2:
                    //sqlPackages = ssisApp.GetDtsServerPackageInfos("File System", ".");
                    break;
                case 3:
                    //sqlPackages = ssisApp.GetPackageInfos(@"\", "(local)", String.Empty, String.Empty);
                    break;
                default:
                    throw new Exception("wrong type");
            }
            //foreach(var p in sqlPackages)
            //{
            //    list.Add(p.Name);
            //}
            return list;
        }
        public static List<string> EnumService()
        {
            List<string> list = new List<string>();
            SqlConnection ssisConnection = new SqlConnection(@"Data Source=.;Integrated Security=SSPI;");
            IntegrationServices service = new IntegrationServices(ssisConnection);
            string s;
            s = $"Name:{service.Name}";
            list.Add(s);
            s = $"Urn:{service.Urn}";
            list.Add(s);
            foreach(var c in service.Catalogs)
            {
                s = $"Catalog:{c.Name}";
                list.Add(s);
            }
            Catalog cat = service.Catalogs["SSISDB"];
            foreach (var f in cat.Folders)
            {
                s = $"Folder:{f.Name}";
                list.Add(s);
            }
            CatalogFolder folder = cat.Folders["Test"];
            foreach (var p in folder.Projects)
            {
                s = $"Project:{p.Name}";
                list.Add(s);
            }
            return list;
        }
    }
}
