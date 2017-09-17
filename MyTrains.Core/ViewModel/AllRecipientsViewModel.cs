using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTrains.Core.ViewModel
{
    public class AllRecipientsViewModel : MvxViewModel
    {
        public List<Recipient> AllRecipients { get; set; }

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        // This is another place that could be improved.
        // We are using the async capabilities built in to SQLite-Net,
        // but in this example, we simply wait for the thread to complete.
        public void Init()
        {
            Task<List<Recipient>> result = Mvx.Resolve<RecipientRepository>().GetAllRecipients();
            result.Wait();
            AllRecipients = result.Result;
        }
    }
}