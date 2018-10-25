﻿using System.Diagnostics;
using System.Reflection;
using Fenit.HelpTool.Core.Service;
using Fenit.HelpTool.UI.Core.Base;
using Fenit.HelpTool.UI.Core.Events;
using Prism.Events;
using Prism.Regions;

namespace Fenit.HelpTool.Module.Footer.ViewModels
{
    public class FooterViewModel : BaseViewModel //, INavigationAware
    {
        private readonly IUserService _userService;
        private bool _footerVisibility;
        private string _version, _userName;

        public FooterViewModel(ILoggerService log, IEventAggregator eventAggregator,
            IUserService userService) : base(log)
        {
            eventAggregator.GetEvent<LoggedInEvent>().Subscribe(LoginReceived, ThreadOption.UIThread);
            _userService = userService;

            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var version = versionInfo.ProductVersion;
            var user = "testowy";
            _version = $"Wersja: {version}";
            _userName = $"Użytkownik: {user}";
            ;
        }

        public bool FooterVisibility
        {
            get => _footerVisibility;
            set => SetProperty(ref _footerVisibility, value);
        }


        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private void LoginReceived()
        {
            if (_userService.IsLogged)
            {
                FooterVisibility = true;
            }
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // throw new NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // throw new NotImplementedException();
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // throw new System.NotImplementedException();
        }
    }
}