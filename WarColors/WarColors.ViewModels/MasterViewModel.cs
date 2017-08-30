using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using WarColors.Core.Navigation;
using WarColors.Models;
using Xamarin.Forms;

namespace WarColors.ViewModels
{
    public class MasterViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private ObservableCollection<MasterViewMenuItem> menuItems;
        private IMyNavigationService navigationService;

        public object ActiveView { get; set; }

        public MasterViewModel(IMyNavigationService navigationService, ProjectListViewModel projectListViewModel)
        {
            this.navigationService = navigationService;

            MenuItems = new ObservableCollection<MasterViewMenuItem>
            {
                    new MasterViewMenuItem { Id = 0, Title = "Color Palette" },
                    new MasterViewMenuItem { Id = 1, Title = "Projects" },
                    new MasterViewMenuItem { Id = 2, Title = "About" }
            };
            var x = ViewLocator.LocateForModelType(typeof(ProjectListViewModel), null, null) as Page;
            this.ActiveView = x;
            this.ActivateItem(projectListViewModel);

        }

        public ObservableCollection<MasterViewMenuItem> MenuItems
        {
            get => menuItems;
            set => SetField(ref menuItems, value);
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, value))
            {
                field = value;
                NotifyOfPropertyChange(propertyName);
                return true;
            }
            return false;
        }
    }
}
