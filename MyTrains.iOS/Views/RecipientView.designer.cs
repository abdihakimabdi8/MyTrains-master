using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyTrains.iOS.Views
{
    partial class RecipientView
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIButton CreateRecipientButton { get; set; }
        [Outlet]

        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIButton CloseButton { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel RecipientViewTitle { get; set; }
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel RecipientNameLabel { get; set; }
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel RecipientPhoneNumberLabel { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField recipientNameTextField { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField recipientPhoneNumberTextField { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (CreateRecipientButton != null)
            {
                CreateRecipientButton.Dispose();
                CreateRecipientButton = null;
            }
            if (CloseButton != null)
            {
                CloseButton.Dispose();
                CloseButton = null;
            }
            if (RecipientViewTitle != null)
            {
                RecipientViewTitle.Dispose();
                RecipientViewTitle = null;
            }
            //if (RecipientNameLabel != null)
            //{
            //    RecipientNameLabel.Dispose();
            //    RecipientNameLabel = null;
            //}
            //if (RecipientPhoneNumberLabel != null)
            //{
            //    RecipientPhoneNumberLabel.Dispose();
            //    RecipientPhoneNumberLabel = null;
            //}
            if (recipientNameTextField != null)
            {
                recipientNameTextField.Dispose();
                recipientNameTextField = null;
            }

            if (recipientPhoneNumberTextField != null)
            {
                recipientPhoneNumberTextField.Dispose();
                recipientPhoneNumberTextField = null;
            }
        }
    }
}
