using Oasys.Common.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oasys.Common.Enums.GameEnums;
using Oasys.Common.GameObject.Clients;
using Oasys.Common.GameObject.Clients.ExtendedInstances;
using Oasys.SDK;
using Oasys.Common.GameObject.ObjectClass;
using Oasys.SDK.Menu;
using Oasys.Common.Menu.ItemComponents;
using Oasys.SDK.Events;
using Oasys.SDK.Rendering;
using Oasys.SDK.Tools;

namespace OasysDebugger
{

    internal class _CoreEvents
    {

        static DateTimeOffset _LastPostTime = DateTimeOffset.FromUnixTimeMilliseconds(0);
        internal static Task MainTick()
        {
            Tab tab = MenuM.TryToInitMenu();
            if (tab.GetItem<Switch>("PassiveDebug").IsOn)
            {
                if (tab.GetItem<Switch>("ConsoleOutput").IsOn)
                    
                    if (TimeSpan.FromSeconds(DateTimeOffset.Now.Second).Seconds - TimeSpan.FromSeconds(_LastPostTime.Second).Seconds > 10)
                    {
                        ReturnToConsole();
                        _LastPostTime = DateTimeOffset.Now;
                    }
                else
                    CoreEvents.OnCoreRender += CoreRenderer;
            } else
            {
                if (!tab.GetItem<Switch>("ConsoleOutput").IsOn)
                    CoreEvents.OnCoreRender -= CoreRenderer;
            }
            return Task.FromResult(0);
        }

        internal static void CoreRenderer()
        {
            int i = 0;
            foreach (BuffEntry buff in UnitManager.MyChampion.BuffManager.GetBuffList())
            {
                if (buff.Name == "UnknownBuff")
                    continue;
                RenderFactory.DrawText($"Buff Name: {buff.Name}\\Buff Count: Int:{buff.BuffCountInt} Float:{buff.BuffCountFloat} Alt:{buff.BuffCountAlt}\\Buff Stacks:{buff.Stacks}\\Buff Duration:{buff.Duration}", 12, new SharpDX.Vector2() { X = 0, Y = 0 + (12 * i) }, new SharpDX.Color() { B = 143, G = 111, R = 233, A = 33 });
                i++;
            }
        }

        internal static void ReturnToConsole()
        {
            foreach (BuffEntry buff in UnitManager.MyChampion.BuffManager.GetBuffList())
            {
                if (buff.Name == "UnknownBuff")
                    continue;
                Logger.Log($"Buff Name: {buff.Name}" +
                $"Buff Count: Int{buff.BuffCountInt} Float{buff.BuffCountFloat} Alt{buff.BuffCountAlt}" +
                $"Buff Times:" +
                $" - Buff Duration: {buff.Duration}/{buff.DurationMs}ms" +
                $" - Buff Start Time: {buff.StartTime}" +
                $" - Buff End Time: {buff.EndTime}" +
                $"Buff Stacks: {buff.Stacks}" +
                $"Buff IsActive: {buff.IsActive}");
            }
        }
    }
}
