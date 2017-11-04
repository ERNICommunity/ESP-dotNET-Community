using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PerformanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewMaster : ContentPage
    {
        public Xamarin.Forms.ListView ListView;

        public MainViewMaster()
        {
            InitializeComponent();

            BindingContext = new MainViewMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainViewMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainViewMenuItem> MenuItems { get; set; }
            
            public MainViewMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainViewMenuItem>(new[]
                {
                    new MainViewMenuItem { Id = 0, Title = "Color Demo", TargetType = typeof(ColorView)},
                    new MainViewMenuItem { Id = 1, Title = "Grid Demo", TargetType = typeof(GridView) },
                    new MainViewMenuItem { Id = 2, Title = "Input Demo", TargetType = typeof(InputView) },
                    new MainViewMenuItem { Id = 3, Title = "List Demo", TargetType = typeof(ListView) },
                    new MainViewMenuItem { Id = 4, Title = "Person Demo", TargetType = typeof(PersonView) },
                    new MainViewMenuItem { Id = 5, Title = "Picker Demo", TargetType = typeof(PickerView) },
                    new MainViewMenuItem { Id = 6, Title = "Style Demo", TargetType = typeof(StylePage) },
                    new MainViewMenuItem { Id = 7, Title = "Custom Demo", TargetType = typeof(UsingCustomView) },
                    new MainViewMenuItem { Id = 7, Title = "ContentTemplate Demo", TargetType = typeof(ContentTeplatePage) }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}