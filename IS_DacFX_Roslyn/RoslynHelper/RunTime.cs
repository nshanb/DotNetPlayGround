using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynHelper
{
    public class RunTime
    {
        // expr is anonymous function
        public static int EvalInt(string expr)
        {
            int i = -1;
            i = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.EvaluateAsync<int>(expr).Result;
            return i;
        }
    }
}
// https://github.com/dotnet/roslyn/wiki/Scripting-API-Samples