using Ernist.Views;
using Xamarin.Forms;

namespace Ernist
{
    /// <summary>
    /// The App class.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new ProjectListView();

        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
