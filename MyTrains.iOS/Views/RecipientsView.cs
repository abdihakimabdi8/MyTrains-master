//using UIKit;
//using Foundation;
//using MvvmCross.iOS.Views;
//using MyTrains.Core.ViewModel;
//using MvvmCross.Binding.iOS.Views;
//using MvvmCross.Binding.BindingContext;
//using System;
//using System.Drawing;
//using MyTrains.iOS.TableViewSources;

//namespace MyTrains.iOS.Views
//{
//    [Register(nameof(RecipientsView))]
//    public class RecipientsView : MvxViewController<AllRecipientsViewModel>
//    {
//        public override void ViewDidLoad()
//        {
//            base.ViewDidLoad();

//            var tableView = new UITableView(UIScreen.MainScreen.Bounds, UITableViewStyle.Plain);
//            tableView.RowHeight = 150;
//            Add(tableView);

//            var source = new MvxSimpleTableViewSource(tableView, RecipientCell.Key, RecipientCell.Key);
//            tableView.Source = source;

//            this.CreateBinding(source).To((AllRecipientsViewModel vm) => vm.AllRecipients).Apply();
//            tableView.ReloadData();
//        }
//    }
//}