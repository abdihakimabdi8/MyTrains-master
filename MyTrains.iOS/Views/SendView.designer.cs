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
	[Register ("SendView")]
	partial class SendView
	{
		//[Outlet]
		//[GeneratedCode ("iOS Designer", "1.0")]
		//UIView calendarContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField serviceTextField { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UITextField recipientTextField { get; set; }

        [Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField cityTextField { get; set; }

        [Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField countryTextField { get; set; }
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton sendButton { get; set; }

		

		void ReleaseDesignerOutlets ()
		{
			//if (calendarContainerView != null) {
			//	calendarContainerView.Dispose ();
			//	calendarContainerView = null;
			//}
			if (serviceTextField != null) {
                serviceTextField.Dispose ();
                serviceTextField = null;
			}
            if (recipientTextField != null)
            {
                recipientTextField.Dispose();
                recipientTextField = null;
            }
            if (cityTextField != null) {
                cityTextField.Dispose ();
                cityTextField = null;
			}
			
			if (countryTextField != null) {
                countryTextField.Dispose ();
                countryTextField = null;
			}

            if (sendButton != null)
            {
                sendButton.Dispose();
                sendButton = null;
            }
        }
	}
}
