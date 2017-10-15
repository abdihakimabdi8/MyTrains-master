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
    [Register("RecipientView")]
    partial class RecipientView
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIButton CreateRecipientButton { get; set; }
        [Outlet]

        [GeneratedCode("iOS Designer", "1.0")]
        UIButton CloseButton { get; set; }

       

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UILabel RecipientNameLabel { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UILabel RecipientViewTitle { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UITextField RecipientPhoneNumberTextField { get; set; }
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UITextField RecipientNameTextField { get; set; }
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UILabel PriceLabel { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UILabel RecipientPhoneNumberLabel { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (CreateRecipientButton != null)
            {
                CreateRecipientButton.Dispose();
                CreateRecipientButton = null;
            }
            if (RecipientNameLabel != null)
            {
                RecipientNameLabel.Dispose();
                RecipientNameLabel = null;
            }
            if (CloseButton != null)
            {
                CloseButton.Dispose();
                CloseButton = null;
            }
            if (RecipientPhoneNumberLabel != null)
            {
                RecipientPhoneNumberLabel.Dispose();
                RecipientPhoneNumberLabel = null;
            }
          
            if (RecipientViewTitle != null)
            {
                RecipientViewTitle.Dispose();
                RecipientViewTitle = null;
            }
            if (RecipientNameTextField != null)
            {
                RecipientNameTextField.Dispose();
                RecipientNameTextField = null;
            }

            if (RecipientPhoneNumberTextField != null)
            {
                RecipientPhoneNumberTextField.Dispose();
                RecipientPhoneNumberTextField = null;
            } 

            if (PriceLabel != null)
            {
                PriceLabel.Dispose();
                PriceLabel = null;
            }
            
        }
    }
}
