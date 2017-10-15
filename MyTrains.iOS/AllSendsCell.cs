using Foundation;
using System;
using System.CodeDom.Compiler;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.Converters;
using MyTrains.Core.Model;
using UIKit;
using MyTrains.Core.Models;

namespace MyTrains.iOS
{
	public partial class AllSendsCell : MvxTableViewCell
	{
        internal static readonly NSString Identifier = 
            new NSString("AllSendsCell");

        public AllSendsCell(IntPtr handle) : base(handle)
        {
        }

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<AllSendsCell, Send>();

            set.Bind(cityLabel)
                .To(vm => vm.CityName);

            set.Bind(countryLabel)
                .To(vm => vm.CountryName);

            set.Bind(serviceLabel)
                .To(vm => vm.ServiceName);

            set.Bind(recipientLabel)
                .To(vm => vm.RecipientName);
            //set.Bind(departureTimeLabel)
            //    .To(vm => vm.DepartureTime)
            //    .WithConversion(new DateTimeToTimeConverter());

            set.Apply();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
        }
    }
}
