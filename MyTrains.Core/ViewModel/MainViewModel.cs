using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Contracts.ViewModel;

namespace MyTrains.Core.ViewModel
{
    public class MainViewModel : MvxViewModel, IMainViewModel
    {

        private readonly Lazy<SendRemittanceViewModel> _sendRemittanceViewModel;
        private readonly Lazy<SavedRemittancesViewModel> _savedRemittancesViewModel;
        private readonly Lazy<SettingsViewModel> _settingsViewModel;

        public SendRemittanceViewModel SendRemittanceViewModel => _sendRemittanceViewModel.Value;

        public SavedRemittancesViewModel SavedRemittancesViewModel => _savedRemittancesViewModel.Value;

        public SettingsViewModel SettingsViewModel => _settingsViewModel.Value;

        public MainViewModel()
        {
            _sendRemittanceViewModel = new Lazy<SendRemittanceViewModel>(Mvx.IocConstruct<SendRemittanceViewModel>);
            _savedRemittancesViewModel = new Lazy<SavedRemittancesViewModel>(Mvx.IocConstruct<SavedRemittancesViewModel>);
            _settingsViewModel = new Lazy<SettingsViewModel>(Mvx.IocConstruct<SettingsViewModel>);
        }

        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }

        public void ShowSendRemittances()
        {
            ShowViewModel<SendRemittanceViewModel>();
        }
    }
}