﻿using System.Windows;
using CommonServiceLocator;
using Fenit.HelpTool.Core.Logger;
using Fenit.HelpTool.Core.Service;
using Fenit.HelpTool.Core.UserService;
using Fenit.HelpTool.Module.Footer;
using Fenit.HelpTool.Module.Login;
using Fenit.HelpTool.Module.SqlLog;
using Prism.Ioc;
using Prism.Modularity;

namespace Fenit.HelpTool.App
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private bool _isRootMode;

        private void AppStartup(object sender, StartupEventArgs e)
        {
            for (var i = 0; i != e.Args.Length; ++i)
                if (e.Args[i] == "-r")
                    _isRootMode = true;
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<ILoggerService, LoggerService>();
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var userService = ServiceLocator.Current.GetInstance<IUserService>();
            userService.IsRootMode = _isRootMode;

            var moduleLogin = typeof(ModuleLogin);
            moduleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = moduleLogin.Name,
                ModuleType = moduleLogin.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
            var moduleSqlLog = typeof(ModuleSqlLog);
            moduleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = moduleSqlLog.Name,
                ModuleType = moduleSqlLog.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
            var moduleFooter = typeof(ModuleFooter);
            moduleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = moduleFooter.Name,
                ModuleType = moduleFooter.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }
    }
}