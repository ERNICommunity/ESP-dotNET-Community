using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarColors.Views
{
    /// <summary>
    /// The ColumnMasterView class.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColumnMasterView : ContentPage
    {
        /// <summary>
        /// The ListView.
        /// </summary>
        public static ListView ListView;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnMasterView"/> class.
        /// </summary>
        public ColumnMasterView()
        {
            InitializeComponent();
            ListView = MenuItemsListView;
        }
    }
}