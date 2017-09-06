using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarColors.Views
{
    /// <summary>
    /// The MasterView class.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.MasterDetailPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : MasterDetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterView"/> class.
        /// </summary>
        public MasterView()
        {
            InitializeComponent();

            Title = "WarColors";
            ColumnMasterView.ListView.ItemSelected += ViewCellTapped;
        }

        private void ViewCellTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (ColumnMasterView.ListView.SelectedItem != null)
            {
                if (Device.RuntimePlatform != Device.Windows)
                {
                    IsPresented = false;
                }

                Title = ColumnMasterView.ListView.SelectedItem.ToString();

                ColumnMasterView.ListView.SelectedItem = null;
            }
        }
    }
}