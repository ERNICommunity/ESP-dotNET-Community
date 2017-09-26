using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarColors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditProjectView : PopupPage
    {
        public AddEditProjectView()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        protected override Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }



        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }
    }
}