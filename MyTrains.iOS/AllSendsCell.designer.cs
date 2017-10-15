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
	[Register ("AllSendsCell")]
	partial class AllSendsCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel cityLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel countryLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel serviceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel recipientLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (cityLabel != null) {
                cityLabel.Dispose ();
                cityLabel = null;
			}
			if (countryLabel != null) {
                countryLabel.Dispose ();
                countryLabel = null;
			}
			if (serviceLabel != null) {
                serviceLabel.Dispose ();
                serviceLabel = null;
			}
			if (recipientLabel != null) {
                recipientLabel.Dispose ();
                recipientLabel = null;
			}
		}
	}
}
