using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Model;

namespace MyTrains.Core.Messages
{
    public class PlatformChangedMessage : MvxMessage
    {
        public PlatformChangedMessage(object sender) : base(sender)
        {
        }

        public Platform NewPlatform { get; set; }
    }
}