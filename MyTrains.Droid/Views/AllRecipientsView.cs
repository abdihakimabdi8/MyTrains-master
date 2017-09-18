using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace MyTrains.Droid.Views
{
    [Activity(Label = "All Recipients", NoHistory = true)]
    public class AllRecipientsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AllRecipientsView);
        }

    }
}