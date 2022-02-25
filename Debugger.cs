using Oasys.SDK;
using Oasys.SDK.Events;

namespace OasysDebugger
{
    public class Debugger
    {
        [OasysModuleEntryPoint]
        internal static void MainEntryPoint()
        {
            GameEvents.OnGameLoadComplete += _GameEvents.OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += _GameEvents.OnGameMatchComplete;
        }
    }
}