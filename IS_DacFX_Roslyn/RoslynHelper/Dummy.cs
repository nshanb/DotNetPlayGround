using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynHelper
{
    // to force to copy referenced dlls to dependent projects
    class Dummy
    {
        // suppress "The field 'xxx' is never used warning
#pragma warning disable 0169
        System.Collections.Immutable.ImmutableList<int> temp;
        System.Reflection.Metadata.Constant temp1;
#pragma warning restore 0169
    }
}
