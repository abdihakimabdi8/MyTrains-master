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
    public partial class SendView : BaseView
    {
        private UIPickerView _recipientTextPicker;
        private UIPickerView _countryTextPicker;
        private UIPickerView _cityTextPicker;
        private UIPickerView _serviceTextPicker;

        private const int TextFieldMargin = 10;
        public static readonly int ArrowWidth = 14;

        protected SendViewModel SendViewModel => ViewModel as SendViewModel;

        public SendView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();

            var set = this.CreateBindingSet<SendView, SendViewModel>();

            set.Bind(sendButton).To(vm => vm.SaveSend);
            CreateRecipientBinding(set);
            CreateCountryBinding(set);
            CreateCityBinding(set);
            CreateServiceBinding(set);
           

            set.Apply();

            UpdateUi();
            AddPickerToTextField(recipientTextField, _recipientTextPicker);       
            AddPickerToTextField(countryTextField, _countryTextPicker);
            AddPickerToTextField(cityTextField, _cityTextPicker);
            AddPickerToTextField(serviceTextField, _serviceTextPicker);
    }

        private void AddPickerToTextField(UITextField textField, UIPickerView pickerView)
        {
            textField.TintColor = UIColor.Clear;

            var leftPaddingView = new UIView(
                new CGRect(0, 0, TextFieldMargin, textField.Frame.Height));
            textField.LeftView = leftPaddingView;
            textField.LeftViewMode = UITextFieldViewMode.Always;

            var arrowImageView = new UIImageView(new CGRect(0, 0,
                ArrowWidth + TextFieldMargin, textField.Frame.Height))
            {
                Image = UIImage.FromBundle("arrow-down.png"),
                ContentMode = UIViewContentMode.Left
            };

            textField.RightView = arrowImageView;
            textField.RightViewMode = UITextFieldViewMode.UnlessEditing;

            textField.InputView = pickerView;

            var toolbar = CreateToolbar();

            textField.InputAccessoryView = toolbar;

            textField.Layer.BorderColor = SaafiColors.BorderColor.CGColor;
            textField.Layer.BorderWidth = 1;
            textField.Layer.CornerRadius = 4;
        }
        private void CreateRecipientBinding(MvxFluentBindingDescriptionSet<SendView, SendViewModel> set)
        {
            set.Bind(recipientTextField).To(vm => vm.SelectedRecipient).OneWay();
            _recipientTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var recipientPickerViewModel = new MvxPickerViewModel(_recipientTextPicker);
            _recipientTextPicker.Model = recipientPickerViewModel;
            set.Bind(recipientPickerViewModel).For(p => p.ItemsSource).To(vm => vm.AllRecipients).OneWay();
            set.Bind(recipientPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedRecipient).OneWayToSource();
        }
       

        private void CreateCountryBinding(MvxFluentBindingDescriptionSet<SendView, SendViewModel> set)
        {
            set.Bind(countryTextField).To(vm => vm.SelectedCountry).OneWay();
            _countryTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var countryPickerViewModel = new MvxPickerViewModel(_countryTextPicker);
            _countryTextPicker.Model = countryPickerViewModel;
            set.Bind(countryPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Countries).OneWay();
            set.Bind(countryPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedCountry).OneWayToSource();
        }
        private void CreateCityBinding(MvxFluentBindingDescriptionSet<SendView, SendViewModel> set)
        {
            set.Bind(cityTextField).To(vm => vm.SelectedCity).OneWay();
            _cityTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var cityPickerViewModel = new MvxPickerViewModel(_cityTextPicker);
            _cityTextPicker.Model = cityPickerViewModel;
            set.Bind(cityPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Cities).OneWay();
            set.Bind(cityPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedCity).OneWayToSource();
        }
        private void CreateServiceBinding(MvxFluentBindingDescriptionSet<SendView, SendViewModel> set)
        {
            set.Bind(serviceTextField).To(vm => vm.SelectedService).OneWay();
            _serviceTextPicker = new UIPickerView
            {
                ShowSelectionIndicator = true
            };

            var servicePickerViewModel = new MvxPickerViewModel(_serviceTextPicker);
            _serviceTextPicker.Model = servicePickerViewModel;
            set.Bind(servicePickerViewModel).For(p => p.ItemsSource).To(vm => vm.Services).OneWay();
            set.Bind(servicePickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedService).OneWayToSource();
        }
       

        private UIToolbar CreateToolbar()
        {
            var toolbar = new UIToolbar(new CGRect(0, 0, 320, 44));

            var done = new UIBarButtonItem("OK", UIBarButtonItemStyle.Bordered, (sender, e) =>
            {
                cityTextField.ResignFirstResponder();
                countryTextField.ResignFirstResponder();
                serviceTextField.ResignFirstResponder();
                recipientTextField.ResignFirstResponder();

            })
            {
                TintColor = SaafiColors.AccentColor
            };

            toolbar.SetItems(new[] { done }, false);

            return toolbar;
        }

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
                recipientTextField.ResignFirstResponder();
                countryTextField.ResignFirstResponder();
                cityTextField.ResignFirstResponder();
                serviceTextField.ResignFirstResponder();
                
            }));
        }

        partial void SendButton_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }
    }
}