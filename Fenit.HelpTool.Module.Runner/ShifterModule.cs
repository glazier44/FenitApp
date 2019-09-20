﻿using Fenit.HelpTool.Module.Runner.Views;
using Fenit.HelpTool.UI.Core;
using Fenit.HelpTool.UI.Core.Base;
using Prism.Ioc;
using Prism.Regions;
using Unity;

namespace Fenit.HelpTool.Module.Runner
{
    public class RunnerModule : BaseModule
    {
        public RunnerModule(IUnityContainer container) : base(container)
        {
        }


        public override void OnInitializedModule(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.Initialize(containerProvider.Resolve<MainWindow>(), ViewReservoir.RunnerModule.Main);
        }

        public override void RegisterModuleTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow>();
        }
    }
}