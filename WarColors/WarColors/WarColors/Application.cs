using Caliburn.Micro.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Core.Injection;
using WarColors.ViewModels;
using Xamarin.Forms;

namespace WarColors
{
    public class Application : FormsApplication
    {
        private readonly IInjectionContainer container;

        public Application(IInjectionContainer container)
        {
            this.container = container;

            container
                .PerRequest<HelloViewModel>();

            Initialize();

            DisplayRootViewFor<HelloViewModel>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
