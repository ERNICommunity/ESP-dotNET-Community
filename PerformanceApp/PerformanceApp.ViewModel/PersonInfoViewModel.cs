using PerformanceApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace PerformanceApp.ViewModel
{
    /// <summary>
    /// The person info view model class.
    /// </summary>
    /// <seealso cref="PerformanceApp.ViewModel.ViewModelBase" />
    public class PersonInfoViewModel : ViewModelBase
    {
        private PersonModel _personInfoModel;
        private string _info;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonInfoViewModel"/> class.
        /// </summary>
        public PersonInfoViewModel()
        {
            PersonInfoModel = new PersonModel();
            UpdateInfo = new Command(SetInfo);
        }

        /// <summary>
        /// Gets the update information.
        /// </summary>
        /// <value>
        /// The update information.
        /// </value>
        public ICommand UpdateInfo { get; private set; }

        /// <summary>
        /// Gets or sets the person model.
        /// </summary>
        /// <value>
        /// The person model.
        /// </value>
        public PersonModel PersonInfoModel
        {
            get => _personInfoModel;
            set => SetProperty(ref _personInfoModel, value);
        }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public string Info
        {
            get => _info;
            set => SetProperty(ref _info, value);
        }

        private void SetInfo()
        {
            Info = string.Format("{0} with email {1} and phone {2} is {3} Developer",
                                 PersonInfoModel.Name, PersonInfoModel.Email, PersonInfoModel.Phone, PersonInfoModel.IsDeveloper ? string.Empty : "not");
        }
    }
}
