using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string name;

        public string Name { get => name; set => SetField(ref name, value); }

        public MainViewModel()
        {
            Name = "Welcome to WarColors!";
        }

    }
}
