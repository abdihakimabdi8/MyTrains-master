//using System;
//using Foundation;
//using UIKit;
//using MvvmCross.Binding.iOS.Views;
//using MvvmCross.Binding.BindingContext;
//using MyTrains.Core.Model;

//namespace MyTrains.iOS
//{
//    public partial class RecipientCell : MvxTableViewCell
//    {
//        public static readonly NSString Key = new NSString(nameof(RecipientCell));
//        public static readonly UINib Nib;
//        internal static NSString Identifier = new NSString("RecipientCell");
//        static RecipientCell()
//        {
//            Nib = UINib.FromName("RecipientCell", NSBundle.MainBundle);
//        }

//        protected RecipientCell(IntPtr handle) : base(handle)
//        {
//            this.DelayBind(() =>
//            {
//                this.CreateBinding(RecipientNameLabel).To((Recipient vm) => vm.RecipientName).Apply();
//                this.CreateBinding(RecipientPhoneNumberLabel).To((Recipient vm) => vm.RecipientPhoneNumber).Apply();
//            });
//        }
//    }
//}