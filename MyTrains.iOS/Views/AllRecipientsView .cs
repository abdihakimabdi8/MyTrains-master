
using System;
using System.Drawing;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.TableViewSources;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class AllRecipientsView : BaseView
    {
        private AllRecipientsTableViewSource _allRecipientsTableViewSource;

        protected AllRecipientsViewModel AllRecipientsViewModel => ViewModel as AllRecipientsViewModel;

        public AllRecipientsView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<AllRecipientsView, AllRecipientsViewModel>();

            set.Bind(_allRecipientsTableViewSource).To(vm => vm.AllRecipients);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            _allRecipientsTableViewSource = new AllRecipientsTableViewSource(allRecipientsTableView);

            base.ViewDidLoad();

            allRecipientsTableView.Source = _allRecipientsTableViewSource;
            //savedJourneyTableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            //savedJourneyTableView.SeparatorColor = UIColor.FromRGB(0, 215, 203);
            allRecipientsTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //AllRecipientsViewModel.ReloadDataCommand.Execute();

            //savedJourneyTableView.DeselectRow(savedJourneyTableView.IndexPathForSelectedRow, true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}