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

namespace MyTrains.UI.iOS.Views
{
    [Register("RecipientCell")]
    partial class RecipientCell
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel RecipientNameLabel { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel RecipientPhoneNumberLabel { get; set; }


        void ReleaseDesignerOutlets()
        {
            if (RecipientNameLabel != null)
            {
                RecipientNameLabel.Dispose();
                RecipientNameLabel = null;
            }

            if (RecipientPhoneNumberLabel != null)
            {
                RecipientPhoneNumberLabel.Dispose();
                RecipientPhoneNumberLabel = null;
            }
        }
    }
}