
using System;
using System.Drawing;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.TableViewSources;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class AllSendsView : BaseView
    {
        private AllSendsTableViewSource _allSendsTableViewSource;

        protected AllSendsViewModel AllSendsViewModel => ViewModel as AllSendsViewModel;

        public AllSendsView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<AllSendsView, AllSendsViewModel>();

            set.Bind(_allSendsTableViewSource).To(vm => vm.AllSends);

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
            _allSendsTableViewSource = new AllSendsTableViewSource(allSendsTableView);

            base.ViewDidLoad();

            allSendsTableView.Source = _allSendsTableViewSource;
            //savedJourneyTableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            //savedJourneyTableView.SeparatorColor = UIColor.FromRGB(0, 215, 203);
            allSendsTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //AllSendsViewModel.ReloadDataCommand.Execute();

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