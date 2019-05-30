﻿using Fenit.HelpTool.Core.Service.Abstract;
using Fenit.HelpTool.Core.Service.Model.Settings;
using Fenit.HelpTool.UI.Core.Base;
using Fenit.HelpTool.UI.Core.Dialog;
using Prism.Commands;

namespace Fenit.HelpTool.Module.Settings.ViewModels
{
    public class ShifterConfigSettingsWindowViewModel : BaseViewModel
    {
        private readonly ISerializationService _serializationService;
        private readonly OpenDialog _openDialog;

        private ShifterConfigSettings _shifterConfig;

        public ShifterConfigSettingsWindowViewModel(ILoggerService log, ISerializationService serializationService) :
            base(log)
        {
            _serializationService = serializationService;
            CreateCommand();
            _openDialog = new OpenDialog();
            LoadData();
        }

        public ShifterConfigSettings ShifterConfigSettings
        {
            get => _shifterConfig;
            set => SetProperty(ref _shifterConfig, value);
        }

        public DelegateCommand OpenSourcePathCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        private void LoadData()
        {
            ShifterConfigSettings = _serializationService.LoadShifterConfigSettings();
        }

        private string GetDir() //TODOTK FRD
        {
            var res = _openDialog.SelectFolder();
            if (res.IsSucces) return res.Value;
            return string.Empty;
        }

        private void CreateCommand()
        {
            OpenSourcePathCommand = new DelegateCommand(() =>
            {
                ShifterConfigSettings.ConfigPath = GetDir();
            });
            SaveCommand = new DelegateCommand(Save);
            //CancelCommand = new DelegateCommand(CancelCopy, CanCancel);
        }
        private bool Valid()
        {
            //TODOTK
            return true;
        }
        private void Save()
        {
            if (!Valid())
            {
                MessageWarning("Prosze uzupełnić wszystkie pola", "Uwaga!");
                return;
            }

            if (ShifterConfigSettings != null)
            {
                _serializationService.SaveShifterConfigSettings(ShifterConfigSettings);
            }
        }

    }
}