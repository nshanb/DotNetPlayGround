using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.LanguageServices;
// Microsoft.VisualStudio.LanguageServices Nuget

/* https://github.com/AArnott/CodeGeneration.Roslyn ??? */
namespace RoslynHelper
{
    public class DesignTime
    {
        public static void ProjectDIr()
        {
            VisualStudioWorkspace workspaceVS;
            MSBuildWorkspace workspaceMS;
            Workspace workspace;
            SourceTextContainer textContainer;
            MSBuildWorkspace.TryGetWorkspace(null, out workspace);
        }
    }
}
