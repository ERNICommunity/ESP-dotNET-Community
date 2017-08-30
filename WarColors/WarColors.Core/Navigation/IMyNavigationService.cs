namespace WarColors.Core.Navigation
{
    /// <summary>
    /// The navigation service interface.
    /// </summary>
    public interface IMyNavigationService
    {
        /// <summary>
        /// Navigates to view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        void NavigateToViewModel<TViewModel>();
    }
}
