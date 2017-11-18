using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using System.Windows.Input;
using Foundation;
using UIKit;
using MvvmCross.Core.ViewModels;

namespace MyTrains.iOS
{
    public class LinkerIncludePlease
    {
        public void Include(UITextField textField)
        {
            textField.Text = textField.Text + "";
        }
        public void Include(UIBarButtonItem button)
        {
            button.Clicked += (sender, e) => { button.Title = button.Title + ""; };
        }
        public void Include(UIButton uiButton)
        {
            uiButton.TouchUpInside += (s, e) =>
                                      uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal);
        }
        public void Include(IMvxCommand command)
        {
            command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
        }
    }
}