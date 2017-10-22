using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.Controls;
using MyTrains.iOS.Utility;
using UIKit;

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
            var set =
                this.CreateBindingSet<RecipientView, RecipientViewModel>();

            //set.Bind(RecipientLabel)
            //    .To(vm => vm.SelectedJourney.JourneyDate)
            //    .WithConversion(new DateTimeToDayConverter());

            //set.Bind(FromCityLabel).To(vm => vm.SelectedJourney.FromCity);
            //set.Bind(ToCityLabel).To(vm => vm.SelectedJourney.ToCity);
            //set.Bind(DepartureTimeLabel)
            //    .To(vm => vm.SelectedJourney.DepartureTime)
            //    .WithConversion(new DateTimeToTimeConverter());
            //set.Bind(ArrivalTimeLabel)
            //    .To(vm => vm.SelectedJourney.ArrivalTime)
            //    .WithConversion(new DateTimeToTimeConverter());
            //set.Bind(PriceLabel)
            //    .To(vm => vm.SelectedJourney.Price)
            //    .WithConversion(new CurrencyToStringConverter());

            //Translations
            //set.Bind(JourneyDetailsViewTitle).To(vm => vm.TextSource)
            //    .WithConversion(new MvxLanguageConverter(),
            //        "JourneyDetailTitleTextView");

            set.Bind(RecipientNameTextField)
                .To(vm => vm.RecipientName).TwoWay();

            set.Bind(RecipientPhoneNumberTextField)
                .To(vm => vm.RecipientPhoneNumber).TwoWay();


            set.Bind(CreateRecipientButton).
                To(vm => vm.SaveRecipient);
            set.Bind(CloseButton).To(vm => vm.NavBack);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CloseButton.Layer.BorderWidth = 1;
            CloseButton.Layer.BorderColor = SaafiColors.AccentColor.CGColor;

            // Perform any additional setup after loading the view, typically from a nib.
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
//using MvvmCross.Binding.BindingContext;
//using MvvmCross.iOS.Views;
//using MyTrains.Core.ViewModel;
//using UIKit;
//using System;
//using MvvmCross.Localization;
//using MyTrains.Core.Converters;
//using MyTrains.iOS.Utility;

//namespace MyTrains.UI.iOS.Views
//{
//    /// <summary>
//    /// Created with the code template View Controller.
//    /// MvvmCross Class Mods:
//    /// Change ineritance to MvxViewController<BillViewModel>
//    /// </summary>
//    public partial class RecipientView : MvxViewController<RecipientViewModel>
//    {
//        public RecipientView(IntPtr handle) : base(handle)
//        {
//            Title = "Add Recipient";
//        }


//            public RecipientView() : base(nameof(RecipientView), null)
//        {
//        }

//        public override void DidReceiveMemoryWarning()
//        {
//            base.DidReceiveMemoryWarning();

//            // Release any cached data, images, etc that aren't in use.
//        }

//        /// <summary>
//        /// MvvmCross Mods:
//        /// Add the data-binding code for MvvmCross here.
//        /// </summary>
//        public override void ViewDidLoad()
//        {
//            base.ViewDidLoad();

//            // This establishes the same sort of data binding in code as what we did in Android's axml.
//            // It means: Bind the VCEmail's default binding property (Text in this case) 
//            // to the ViewModel's CustomerEmail property.
//            // 2-way binding by default.
//            this.CreateBinding(RecipientNameTextField).To((RecipientViewModel vm) => vm.RecipientName).Apply();

//            // This is a similar example, but demonstrates binding to a specific property (Text).
//            this.CreateBinding(RecipientPhoneNumberTextField).To((RecipientViewModel vm) => vm.RecipientPhoneNumber).Apply();

//            // This ensures that the virtual keyboard is closed after text input.
//            View.AddGestureRecognizer(new UITapGestureRecognizer(() => {
//                this.RecipientNameTextField.ResignFirstResponder();
//                this.RecipientPhoneNumberTextField.ResignFirstResponder();
//            }));
//        }
//        //public override void ViewWillAppear(bool animated)
////        {
////            base.ViewWillAppear(animated);
////        }

//        //        public override void ViewDidAppear(bool animated)
//        //        {
//        //            base.ViewDidAppear(animated);
//        //        }

//        //        public override void ViewWillDisappear(bool animated)
//        //        {
//        //            base.ViewWillDisappear(animated);
//        //        }

//        //        public override void ViewDidDisappear(bool animated)
//        //        {
//        //            base.ViewDidDisappear(animated);
//        //        }

//    }
//}
