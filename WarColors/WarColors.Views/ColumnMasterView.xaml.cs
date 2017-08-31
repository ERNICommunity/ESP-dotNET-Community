using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarColors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColumnMasterView : ContentPage
    {
        public static ListView ListView;

        public ColumnMasterView()
        {
            InitializeComponent();
            ListView = MenuItemsListView;
        }
    }
}