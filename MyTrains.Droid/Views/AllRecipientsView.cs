using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MyTrains.Core.ViewModel;
using MyTrains.Droid.Activities;
using MyTrains.Droid.Extensions;

namespace MyTrains.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("mytrains.droid.views.AllRecipientsView")]
    public class AllRecipientsView : MvxFragment<AllRecipientsViewModel>
   // [Activity(Label = "All Recipients", NoHistory = true)]
    {
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //    SetContentView(Resource.Layout.AllRecipientsView);
        //}
        //{
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                return this.BindingInflate(Resource.Layout.AllRecipientsView, null);
            }

            public override void OnViewCreated(View view, Bundle savedInstanceState)
            {
                base.OnViewCreated(view, savedInstanceState);
                (this.Activity as MainActivity).SetCustomTitle("Recipients");
            }
        }
 }