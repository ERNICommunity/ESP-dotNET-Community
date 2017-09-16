using Caliburn.Micro;
using System.Runtime.CompilerServices;

namespace WarColors.ViewModels
{
    public class ViewModelBase : Screen
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, value))
            {
                field = value;
                NotifyOfPropertyChange(propertyName);
                return true;
            }
            return false;
        }
    }
}
