using Ernist.ViewModels.Base;

namespace Ernist.ViewModels.UnitTests
{
    /// <summary>
    /// The class view model class.
    /// </summary>
    /// <seealso cref="Ernist.ViewModels.Base.ViewModelBase" />
    public class ClassViewModel : ViewModelBase
    {
        private string _property1;
        private string _property2;

        /// <summary>
        /// Gets or sets the property1.
        /// </summary>
        /// <value>
        /// The property1.
        /// </value>
        public string Property1
        {
            get { return _property1; }
            set { SetProperty(ref _property1, value); }
        }

        /// <summary>
        /// Gets or sets the property2.
        /// </summary>
        /// <value>
        /// The property2.
        /// </value>
        public string Property2
        {
            get { return _property2; }
            set { SetProperty(ref _property2, value); }
        }
    }
}
