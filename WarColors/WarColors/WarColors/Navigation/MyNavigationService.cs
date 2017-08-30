using Caliburn.Micro.Xamarin.Forms;
using WarColors.Core.Navigation;

namespace WarColors.Navigation
{
    /// <summary>
    /// The navigation service class.
    /// </summary>
    /// <seealso cref="WarColors.Core.Navigation.IMyNavigationService" />
    public class MyNavigationService : IMyNavigationService
    {
        private INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyNavigationService"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public MyNavigationService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        /// <summary>
        /// Navigates to view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void NavigateToViewModel<TViewModel>()
        {
            this.navigationService.NavigateToViewModelAsync<TViewModel>();
        }
    }
}
