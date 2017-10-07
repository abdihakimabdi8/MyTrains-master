using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTrains.Core.ViewModel
{
    public class AllSendViewModel : MvxViewModel
    {
        public List<Send> AllSends { get; set; }

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
            Task<List<Send>> result = Mvx.Resolve<SendRepository>().GetAllSends();
            result.Wait();
            AllSends = result.Result;
        }
    }
}