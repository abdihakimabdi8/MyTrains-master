using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.Controls;
using MyTrains.iOS.Utility;
using UIKit;
using MyTrains.Core.Models;

namespace MyTrains.iOS.Views
{
    public partial class RecipientView : BaseView
    {

        protected RecipientViewModel RecipientViewModel
             => ViewModel as RecipientViewModel;

        public RecipientView(IntPtr handle) : base(handle)
        {
            Title = "Add Recipient";
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<RecipientView, RecipientViewModel>();

            CreateRecipientNameBindings(set);
            CreateRecipientPhoneNumberBindings(set);
            set.Bind(RecipientNameTextField).To(vm => vm.RecipientName);

            set.Bind(RecipientPhoneNumberTextField).To(vm => vm.RecipientPhoneNumber);


            set.Bind(CreateRecipientButton).To(vm => vm.SaveRecipient);
            set.Bind(CloseButton).To(vm => vm.CloseCommand);
            UpdateUi();

            set.Apply();
        }

        private void CreateRecipientNameBindings(MvxFluentBindingDescriptionSet<RecipientView, RecipientViewModel> set)
        {
            set.Bind(RecipientNameTextField).To(vm => vm.RecipientName);
        }
        private void CreateRecipientPhoneNumberBindings(MvxFluentBindingDescriptionSet<RecipientView, RecipientViewModel> set)
        {
            set.Bind(RecipientPhoneNumberTextField).To(vm => vm.RecipientPhoneNumber);
        }
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle
        protected void UpdateUi()
        {
            //var calendar = CalendarHelper.GetPreconfiguredInstance(
            //    new CGRect(0, 0, View.Frame.Width - 32, 273),
            //    date => SendViewModel.SelectedDate = date);

            //calendarContainerView.AddSubview(calendar);
            //calendarContainerView.Layer.BorderWidth = 1;
            //calendarContainerView.Layer.BorderColor = SaafiColors.BorderColor.CGColor;
            //calendarContainerView.Layer.CornerRadius = 4;

            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                RecipientNameTextField.ResignFirstResponder();
                RecipientPhoneNumberTextField.ResignFirstResponder();
               

            }));
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CloseButton.Layer.BorderWidth = 1;
            CloseButton.Layer.BorderColor = SaafiColors.AccentColor.CGColor;

            //RecipientNameTextField.ShouldReturn = (textField) =>
            //{
            //    textField.ResignFirstResponder();
            //    return true;
            //};
            //RecipientPhoneNumberTextField.ShouldReturn = (textField) =>
            //{
            //    textField.ResignFirstResponder();
            //    return true;
            //};

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5
            View.AddGestureRecognizer(g);
            //Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }
        #endregion
      
    }
}
