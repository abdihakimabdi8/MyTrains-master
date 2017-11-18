using Foundation;
using System;
using System.CodeDom.Compiler;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.Converters;
using MyTrains.Core.Model;
using UIKit;
using MyTrains.Core.ViewModel;

namespace MyTrains.iOS
{
	partial class AllRecipientsCell : MvxTableViewCell
    {
        //protected AllRecipientsViewModel AllRecipientViewModel
        //   => ViewModel as AllRecipientsViewModel;
        public AllRecipientsCell (IntPtr handle) : base (handle)
		{
		}

	    internal static NSString Identifier = new NSString("AllRecipientsCell");

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<AllRecipientsCell, Recipient>();

            set.Bind(RecipientNameLabel)
                .To(vm => vm.RecipientName);

            set.Bind(RecipientPhoneNumberLabel)
                .To(vm => vm.RecipientPhoneNumber);



            set.Apply();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
        }
    }
}
