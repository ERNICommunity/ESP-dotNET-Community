using Caliburn.Micro.Xamarin.Forms;
using System.Linq;
using System.Reflection;
using WarColors.Core.Injection;
using WarColors.Core.Navigation;
using WarColors.Data.Marcello;
using WarColors.Data.Repositories;
using WarColors.Navigation;
using WarColors.ViewModels;
using WarColors.Views;
using Xamarin.Forms;

namespace WarColors
{
    public class Application : FormsApplication
    {
        private readonly IInjectionContainer container;

        public Application(IInjectionContainer container)
        {
            this.container = container;

            RegisterViewModels();

            RegisterServices();

            Initialize();

            DisplayRootView<MasterView>();
            //DisplayRootViewFor<MasterViewModel>();
        }

        private void RegisterServices()
        {
            container
                .PerRequest<IProjectRepository, ProjectRepository>()
                .PerRequest<IMyNavigationService, MyNavigationService>();
        }

        private void RegisterViewModels()
        {
            var assembly = typeof(ProjectListViewModel).GetTypeInfo().Assembly;

            foreach (var vm in assembly.DefinedTypes.Where(ti => ti.BaseType == typeof(ViewModelBase)))
            {
                container
                    .PerRequest(vm.AsType());
            }

            container
                .PerRequest(typeof(MasterViewModel))
                .PerRequest(typeof(ProjectListView));
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
