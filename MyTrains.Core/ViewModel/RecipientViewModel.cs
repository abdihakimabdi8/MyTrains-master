using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Models;
using MyTrains.Core.Services;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MyTrains.Core.ViewModel
{
    /// <summary>
    /// All view models inherit from MvxViewModel in MVVMCross
    /// </summary>
    public class RecipientViewModel : MvxViewModel
    {
       // readonly IBillCalculator _calculation;
        Recipient _recipient;

        public string RecipientName
        {
            get { return _recipient.RecipientName; }
            set
            {
                _recipient.RecipientName = value;
                RaisePropertyChanged(() => RecipientName);
            }
        }

        public string RecipientPhoneNumber
        {
            get { return _recipient.RecipientPhoneNumber; }
            set
            {
                _recipient.RecipientPhoneNumber = value;
                RaisePropertyChanged(() => RecipientPhoneNumber);
            }
        }

        /// <summary>
        /// Use constructor injection to supply _calculation with the implementation.
        /// </summary>
        /// <param name="calculation"></param>
        //public RecipientViewModel(IBillCalculator calculation)
        //{
        //    _calculation = calculation;
        //}

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
        public MvxCommand CloseCommand
        { get { return new MvxCommand(() => Close(this)); } }
        public ICommand SaveRecipient
        {
            get
            {
                return new MvxCommand(() => {
                    if (_recipient.IsValid())
                    {
                        // Here we are simply waiting for the thread to complete.
                        // In a production app, this would be the opportunity to
                        // provide UI updates while the save thread completes.
                        Mvx.Resolve<RecipientRepository>().CreateRecipient(_recipient).Wait();
                        Close(this);
                    }
                });
            }
        }

        public void Init(Recipient recipient = null)
        {
            _recipient = recipient == null ? new Recipient() : recipient;
            RaiseAllPropertiesChanged();
        }
    }
}