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
                Icon = "send",
                ViewModelType = typeof(SendViewModel),
                Option = MenuOption.Send,
                IsSelected = true
            });
            MenuItems.Add(new MenuItem
            {
                Title = "Transfers",
                Icon = "allsends",
                ViewModelType = typeof(AllSendsViewModel),
                Option = MenuOption.AllSends,
                IsSelected = true
            });

            MenuItems.Add(new MenuItem
            {
                Title = "Add Recipient",
                Icon = "allsends.png",
                ViewModelType = typeof(RecipientViewModel),
                Option = MenuOption.CreateRecipient,
                IsSelected = true
            });
            MenuItems.Add(new MenuItem
            {
                Title = "Recipients",
                Icon = "allsends",
                ViewModelType = typeof(AllRecipientsViewModel),
                Option = MenuOption.AllRecipients,
                IsSelected = true
            });

            MenuItems.Add(new MenuItem
            {
                Title = "Settings",
                Icon = "Settings",
                ViewModelType = typeof(SettingsViewModel),
                Option = MenuOption.Settings,
                IsSelected = true
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