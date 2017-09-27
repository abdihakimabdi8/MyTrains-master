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
    public class TransferViewModel : MvxViewModel
    {
        // readonly IBillCalculator _calculation;
        Transfer _transfer;

        public string Recipient
        {
            get { return _transfer.Recipient; }
            set
            {
                _transfer.Recipient = value;
                RaisePropertyChanged(() => Recipient);
            }
        }

        public string Country
        {
            get { return _transfer.Country; }
            set
            {
                _transfer.Country = value;
                RaisePropertyChanged(() => Country);
            }
        }
        public string City
        {
            get { return _transfer.City; }
            set
            {
                _transfer.City = value;
                RaisePropertyChanged(() => City);
            }
        }

        public string Service
        {
            get { return _transfer.Service; }
            set
            {
                _transfer.Service = value;
                RaisePropertyChanged(() => Service);
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

        public ICommand SaveTransfer
        {
            get
            {
                return new MvxCommand(() => {
                    if (_transfer.IsValid())
                    {
                        // Here we are simply waiting for the thread to complete.
                        // In a production app, this would be the opportunity to
                        // provide UI updates while the save thread completes.
                        Mvx.Resolve<TransferRepository>().CreateTransfer(_transfer).Wait();
                        Close(this);
                    }
                });
            }
        }

        public void Init(Transfer transfer = null)
        {
            _transfer = transfer == null ? new Transfer() : transfer;
            RaiseAllPropertiesChanged();
        }
    }
}