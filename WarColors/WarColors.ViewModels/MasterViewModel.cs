using System.Collections.ObjectModel;
using WarColors.Models;

namespace WarColors.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        private ObservableCollection<MasterViewMenuItem> menuItems;

        public MasterViewModel()
        {
            MenuItems = new ObservableCollection<MasterViewMenuItem>
            {
                    new MasterViewMenuItem { Id = 0, Title = "Color Palette" },
                    new MasterViewMenuItem { Id = 1, Title = "Projects" },
                    new MasterViewMenuItem { Id = 2, Title = "About" }
            };
        }

        public ObservableCollection<MasterViewMenuItem> MenuItems
        {
            get => menuItems;
            set => SetField(ref menuItems, value);
        }
    }
}
