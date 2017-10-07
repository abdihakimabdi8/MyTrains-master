using System;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Model.App;
using MyTrains.Core.Utility;
using System.Windows.Input;

namespace MyTrains.Core.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public MvxCommand<MenuItem> MenuItemSelectCommand => new MvxCommand<MenuItem>(OnMenuEntrySelect);
        public ObservableCollection<MenuItem> MenuItems { get; }

        public event EventHandler CloseMenu;

        public MenuViewModel(IMvxMessenger messenger) : base(messenger)
        {
            MenuItems = new ObservableCollection<MenuItem>();
            CreateMenuItems();
        }

        private void CreateMenuItems()
        {
            MenuItems.Add(new MenuItem
            {
                Title = "Send Money",
                ViewModelType = typeof(SendViewModel),
                Option = MenuOption.Send,
                IsSelected = false
            });
            MenuItems.Add(new MenuItem
            {
                Title = "Transfers",
                ViewModelType = typeof(AllSendViewModel),
                Option = MenuOption.AllSends,
                IsSelected = false
            });
            MenuItems.Add(new MenuItem
            {
                Title = "Transactions",
                ViewModelType = typeof(AllTransfersViewModel),
                Option = MenuOption.AllTransfers,
                IsSelected = false
            });
            MenuItems.Add(new MenuItem
            {
                Title = "Add Recipient",
                ViewModelType = typeof(RecipientViewModel),
                Option = MenuOption.CreateRecipient,
                IsSelected = false
            });
            MenuItems.Add(new MenuItem
            {
                Title = "Recipients",
                ViewModelType = typeof(AllRecipientsViewModel),
                Option = MenuOption.AllRecipients,
                IsSelected = false
            });

            MenuItems.Add(new MenuItem
            {
                Title = "Settings",
                ViewModelType = typeof(SettingsViewModel),
                Option = MenuOption.Settings,
                IsSelected = false
            });
           
        }

            public ICommand NavigateCreateRecipient
            {
                get
                {
                    // Navigation Note:
                    // Must add following value to Assembly.cs for any Windows projects to see the lambda.
                    // [assembly: InternalsVisibleTo("Cirrious.MvvmCross")]
                    return new MvxCommand(() => ShowViewModel<RecipientViewModel>());
                }
            }

            public ICommand NavigateAllRecipients
            {
                get
                {
                    // Navigation Note:
                    // Must add following value to Assembly.cs for any Windows projects to see the lambda.
                    // [assembly: InternalsVisibleTo("Cirrious.MvvmCross")]
                    return new MvxCommand(() => ShowViewModel<AllRecipientsViewModel>());
                }
            }

        public ICommand NavigateCreateTransfer
        {
            get
            {
                // Navigation Note:
                // Must add following value to Assembly.cs for any Windows projects to see the lambda.
                // [assembly: InternalsVisibleTo("Cirrious.MvvmCross")]
                return new MvxCommand(() => ShowViewModel<TransferViewModel>());
            }
        }

        public ICommand NavigateAllTransfers
        {
            get
            {
                // Navigation Note:
                // Must add following value to Assembly.cs for any Windows projects to see the lambda.
                // [assembly: InternalsVisibleTo("Cirrious.MvvmCross")]
                return new MvxCommand(() => ShowViewModel<AllTransfersViewModel>());
            }
        }
        private void OnMenuEntrySelect(MenuItem item)
        {
            ShowViewModel(item.ViewModelType);
            RaiseCloseMenu();
        }

        private void RaiseCloseMenu()
        {
            CloseMenu?.Invoke(this, EventArgs.Empty);
        }
    }
}