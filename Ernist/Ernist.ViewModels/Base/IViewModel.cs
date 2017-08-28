using System.ComponentModel;

namespace Ernist.ViewModels.Base
{
    public interface IViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}