using PerformanceApp.Models;
using System.Collections.ObjectModel;

namespace PerformanceApp.ViewModel
{
    /// <summary>
    /// The color view model class.
    /// </summary>
    /// <seealso cref="PerformanceApp.ViewModel.ViewModelBase" />
    public class ColorViewModel : ViewModelBase
    {
        private ObservableCollection<ColorModel> _observableCollectionColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorViewModel"/> class.
        /// </summary>
        public ColorViewModel()
        {
            ObservableCollectionColor = new ObservableCollection<ColorModel>
            {
                new ColorModel { Name = "Red", Description = "Color 1" },
                new ColorModel { Name = "Green", Description = "Color 2" },
                new ColorModel { Name = "Blue", Description = "Color 3" }
            };
        }

        /// <summary>
        /// Gets or sets the color of the observable collection.
        /// </summary>
        /// <value>
        /// The color of the observable collection.
        /// </value>
        public ObservableCollection<ColorModel> ObservableCollectionColor
        {
            get => _observableCollectionColor;
            set => SetProperty(ref _observableCollectionColor, value);
        }
    }
}
