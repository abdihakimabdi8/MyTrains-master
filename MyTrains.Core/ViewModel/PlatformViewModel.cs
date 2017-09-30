using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Plugins.WebBrowser;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Messages;
using MyTrains.Core.Model;

namespace MyTrains.Core.ViewModel
{
    public class PlatformViewModel : BaseViewModel, IPlatformViewModel
    {
        private readonly IPlatformDataService _platformDataService;
        private string _aboutContent;
        private readonly IMvxWebBrowserTask _webBrowser;

        public MvxCommand HelpCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _webBrowser.ShowWebPage
                        ("http://www.snowball.be");//what an awesome site!
                });
            }
        }
        public MvxCommand SwitchCurrencyCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Messenger.Publish(
                        new PlatformChangedMessage(this)
                        { NewPlatform = ActivePlatform });
                    _platformDataService.SetActivePlatform(ActivePlatform);
                });
            }
        }

        private ObservableCollection<Platform> _platforms;
        private Platform _activePlatform;

        public Platform ActivePlatform
        {
            get { return _activePlatform; }
            set
            {
                _activePlatform = value;
                RaisePropertyChanged(() => ActivePlatform);
            }
        }

        public string AboutContent
        {
            get { return _aboutContent; }
            set
            {
                _aboutContent = value;
                RaisePropertyChanged(() => AboutContent);
            }
        }

        public ObservableCollection<Platform> Platforms
        {
            get { return _platforms; }
            set
            {
                _platforms = value;
                RaisePropertyChanged(() => Platforms);
            }
        }

        public PlatformViewModel(IMvxMessenger messenger, IPlatformDataService platformDataService, IMvxWebBrowserTask webBrowser) : base(messenger)
        {
            _platformDataService = platformDataService;
            _webBrowser = webBrowser;

        }



        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                Platforms = _platformDataService.GetPlatforms().ToObservableCollection();
                AboutContent = _platformDataService.GetAboutContent();
                ActivePlatform = Platforms[0];
            });
        }
    }
}