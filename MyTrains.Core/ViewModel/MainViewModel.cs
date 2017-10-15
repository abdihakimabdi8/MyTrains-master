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

        private readonly Lazy<PlatformViewModel> _platformViewModel;
        private readonly Lazy<SavedBeneficiariesViewModel> _savedBeneficiariesViewModel;
        private readonly Lazy<SendViewModel> _sendViewModel;
        private readonly Lazy<AllSendsViewModel> _allSendsViewModel;
        private readonly Lazy<AllRecipientsViewModel> _allRecipientsViewModel;
        private readonly Lazy<RecipientViewModel> _recipientViewModel;


        public SendViewModel SendViewModel => _sendViewModel.Value;

        public SendRemittanceViewModel SendRemittanceViewModel => _sendRemittanceViewModel.Value;

        public SavedRemittancesViewModel SavedRemittancesViewModel => _savedRemittancesViewModel.Value;
        public SavedBeneficiariesViewModel SavedBeneficiariesViewModel => _savedBeneficiariesViewModel.Value;

        public SettingsViewModel SettingsViewModel => _settingsViewModel.Value;
        public PlatformViewModel PlatformViewModel => _platformViewModel.Value;
        public AllSendsViewModel AllSendsViewModel => _allSendsViewModel.Value;
        public AllRecipientsViewModel AllRecipientsViewModel => _allRecipientsViewModel.Value;
        public RecipientViewModel RecipientViewModel => _recipientViewModel.Value;


        public MainViewModel()
        {
            _sendViewModel = new Lazy<SendViewModel>(Mvx.IocConstruct<SendViewModel>);
            _sendRemittanceViewModel = new Lazy<SendRemittanceViewModel>(Mvx.IocConstruct<SendRemittanceViewModel>);
            _savedRemittancesViewModel = new Lazy<SavedRemittancesViewModel>(Mvx.IocConstruct<SavedRemittancesViewModel>);
            _savedBeneficiariesViewModel = new Lazy<SavedBeneficiariesViewModel>(Mvx.IocConstruct<SavedBeneficiariesViewModel>);
            _platformViewModel = new Lazy<PlatformViewModel>(Mvx.IocConstruct<PlatformViewModel>);
            _settingsViewModel = new Lazy<SettingsViewModel>(Mvx.IocConstruct<SettingsViewModel>);
            _allSendsViewModel = new Lazy<AllSendsViewModel>(Mvx.IocConstruct<AllSendsViewModel>);
            _allRecipientsViewModel = new Lazy<AllRecipientsViewModel>(Mvx.IocConstruct<AllRecipientsViewModel>);
            _recipientViewModel = new Lazy<RecipientViewModel>(Mvx.IocConstruct<RecipientViewModel>);

        }

        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }

        public void ShowSendRemittances()
        {
            ShowViewModel<SendViewModel>();
        }
    }
}