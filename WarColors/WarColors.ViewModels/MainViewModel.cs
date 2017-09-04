namespace WarColors.ViewModels
{
    /// <summary>
    /// The MainViewModel class.
    /// </summary>
    /// <seealso cref="WarColors.ViewModels.ViewModelBase" />
    public class MainViewModel : ViewModelBase
    {
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            Name = "Welcome to WarColors!";
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get => name; set => SetField(ref name, value); }
    }
}
