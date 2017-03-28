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
            //Solution s = new Solution();
            //AppDomain.CurrentDomain;
            VisualStudioWorkspace workspaceVS;
            MSBuildWorkspace workspaceMS = MSBuildWorkspace.Create();
            Workspace workspace;
            //SourceTextContainer textContainer = new SourceTextContainer();
            //Workspace.TryGetWorkspace(null, out workspace);
            //MSBuildWorkspace.TryGetWorkspace(null, out workspace);
            //VisualStudioWorkspace.TryGetWorkspace(null, out workspace);
            //workspace.CurrentSolution
        }
    }
}
// https://github.com/dotnet/roslyn/blob/667fc2434222e2d735d6c120c19a8e0cd9325044/docs/features/generators.md