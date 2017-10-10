using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTrains.Core.ViewModel
{
    public class AllSendsViewModel : MvxViewModel
    {
        public List<Send> AllSends { get; set; }

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
        public void Init()
        {

        }
        // This is another place that could be improved.
        // We are using the async capabilities built in to SQLite-Net,
        // but in this example, we simply wait for the thread to complete.
        //public Task<List<Send>> GetAllSends(SQLiteAsyncConnection conn, Send send)
        //{
        //    return conn.QueryAsync<Send>("select * from Valuation where StockId = ?", send.RecipientId);
        //    //return conn.Table<Send>().ToListAsync();

        //}

        public void Init(SQLiteAsyncConnection conn, Send send)
        {
                Task<List<Send>> result = Mvx.Resolve<SendRepository>().GetAllSends();
                result.Wait();
                AllSends = result.Result;
               
                
        }
    }
}