using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasysDebugger
{
    internal partial class _GameEvents
    {
        internal static Task OnGameMatchComplete()
        {
            return Task.CompletedTask;
        }
    }
}
