using Oasys.Common.Menu;
using Oasys.Common.Menu.ItemComponents;
using Oasys.SDK;
using Oasys.SDK.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oasys.Common.Enums.GameEnums;
using Oasys.Common.GameObject.Clients;
using Oasys.Common.GameObject.Clients.ExtendedInstances;
using Oasys.SDK.Events;
using Oasys.SDK.Tools;
namespace OasysDebugger
{
    internal class MenuM
    {

        internal static Tab TryToInitMenu()
        {
            if (MenuManager.GetTab("OKDebug") == null)
            {
                int TabIndex = MenuManager.AddTab(new Tab() { Title = "OKDebug" });
                Logger.Log($"Does not exist!\n TabIndex: {TabIndex}");
                MenuManager.GetTab("OKDebug").AddItem(new() { Title = "OKDebug", TabName = "OKDebug" });
                MenuManager.GetTab("OKDebug").AddItem(new Switch() { Title = "PassiveDebug", TabName = "PassiveDebug", IsOn = true });
                MenuManager.GetTab("OKDebug").AddItem(new Switch() { Title = "ConsoleOutput", TabName = "ConsoleOutput", IsOn = true });
                Logger.Log($"Exists? {MenuManager.GetTab("OKDebug") == null}");
            } else
            {
                //Logger.Log($"{MenuManager.GetTab("OKDebug").Title}");
                //Logger.Log($"{MenuManager.GetTab("OKDebug").GetItem<Switch>("PassiveDebug").IsOn}");
                //Logger.Log($"{MenuManager.GetTab("OKDebug").GetItem<Switch>("ConsoleOutput").IsOn}");
            }
            return MenuManager.GetTab("OKDebug");
        }
    }

    internal partial class _GameEvents
    {
        internal static Task OnGameLoadComplete()
        {
            
            CoreEvents.OnCoreMainTick += _CoreEvents.MainTick;
            
            return Task.CompletedTask;
        }
    }
}
