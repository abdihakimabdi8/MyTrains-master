using System;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MyTrains.iOS.TableViewSources
{
    public class AllRecipientsTableViewSource: MvxTableViewSource
    {
        public AllRecipientsTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public AllRecipientsTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ItemsSource.Count();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (AllRecipientsCell)tableView.DequeueReusableCell(AllRecipientsCell.Identifier);
            return cell;
        }
    }
}