﻿using Fenit.HelpTool.Core.Service;
using Fenit.HelpTool.Core.SqlFileService.Enum;
using Fenit.HelpTool.UI.Core.Base;
using Prism.Commands;

namespace Fenit.HelpTool.Module.SqlLog.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ISqlFileService _sqlFileService;

        private string _resultText, _sourceText;
        private SqlType SqlType;

        public MainWindowViewModel(ISqlFileService sqlFileService, ILoggerService log) : base(log)
        {
            _sqlFileService = sqlFileService;
            ConvertCommand = new DelegateCommand(Convert);
            LoadFileCommand = new DelegateCommand(LoadFile, False);
            RadioButonCommand = new DelegateCommand<object>(RadioButonClick);
        }

        public DelegateCommand<object> RadioButonCommand { get; set; }
        public DelegateCommand ConvertCommand { get; set; }
        public DelegateCommand LoadFileCommand { get; set; }

        public string ResultText
        {
            get => _resultText;
            set => SetProperty(ref _resultText, value);
        }


        public string SourceText
        {
            get => _sourceText;
            set
            {
                SetProperty(ref _sourceText, value);
                ConvertCommand.RaiseCanExecuteChanged();
            }
        }

        private void RadioButonClick(object parameter)
        {
            SqlType = SqlType.Non;
        }


        private bool False()
        {
            return false;
        }

        private bool CanConvert()
        {
            return !string.IsNullOrEmpty(_sourceText);
        }

        private void Convert()
        {
            var res = SqlType == SqlType.Select
                ? _sqlFileService.ReadSelect(SourceText)
                : _sqlFileService.ReadProcedure(SourceText);
            if (res.IsError)
                MessageError(res.Message, "[SqlLoad]");
            else
                ResultText = res.Value;
        }

        private void LoadFile()
        {
        }
    }
}