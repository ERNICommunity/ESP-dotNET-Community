using Caliburn.Micro;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;

namespace WarColors.UWP
{
    internal class HostView : WindowsPage
    {
        public HostView()
        {
            LoadApplication(IoC.Get<Application>());
        }
    }
}