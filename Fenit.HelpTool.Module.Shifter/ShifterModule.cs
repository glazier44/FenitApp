﻿using Fenit.HelpTool.Core.FileService;
using Fenit.HelpTool.Core.Service;
using Fenit.HelpTool.Core.SqlFileService;
using Fenit.HelpTool.Module.Shifter.Views;
using Fenit.HelpTool.UI.Core;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Fenit.HelpTool.Module.Shifter
{
    public class ShifterModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.Initialize(containerProvider.Resolve<MainWindow>(), ViewReservoir.ShifterModule.Main);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow>();
            //containerRegistry.RegisterSingleton<ISqlFileService, SqlFileService>();
            //containerRegistry.RegisterSingleton<IFileService, FileService>();
        }
    }
}