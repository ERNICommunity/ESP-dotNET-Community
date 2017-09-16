using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarColors.Views
{
    /// <summary>
    /// The MiniView content view.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiniView : ContentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiniView"/> class.
        /// </summary>
        public MiniView()
        {
            InitializeComponent();
        }
    }
}