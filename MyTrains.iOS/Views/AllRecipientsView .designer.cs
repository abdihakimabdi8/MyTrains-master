// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyTrains.iOS.Views
{
	[Register ("AllRecipientsView")]
	partial class AllRecipientsView
    {
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView allRecipientsTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (allRecipientsTableView != null) {
                allRecipientsTableView.Dispose ();
                allRecipientsTableView = null;
			}
		}
	}
}
