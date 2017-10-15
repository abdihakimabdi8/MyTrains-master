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
	[Register ("AllSendsView")]
	partial class AllSendsView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView allSendsTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (allSendsTableView != null) {
				allSendsTableView.Dispose ();
				allSendsTableView = null;
			}
		}
	}
}
