using Caliburn.Micro;
using System.Runtime.CompilerServices;

namespace WarColors.ViewModels
{
    public class ViewModelBase : Screen
    {
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
