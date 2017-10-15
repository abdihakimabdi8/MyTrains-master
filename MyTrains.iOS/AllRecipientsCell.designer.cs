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

namespace MyTrains.iOS
{
	[Register ("AllRecipientsCell")]
	partial class AllRecipientsCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel RecipientNameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel RecipientPhoneNumberLabel { get; set; }

	

		void ReleaseDesignerOutlets ()
		{
			if (RecipientNameLabel != null) {
                RecipientNameLabel.Dispose ();
                RecipientNameLabel = null;
			}
			if (RecipientPhoneNumberLabel != null) {
                RecipientPhoneNumberLabel.Dispose ();
                RecipientPhoneNumberLabel = null;
			}
		}
	}
}
