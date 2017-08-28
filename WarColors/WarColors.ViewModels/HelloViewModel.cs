using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.ViewModels
{
    public class HelloViewModel : ViewModelBase
    {
        private string name;
        private string greeting;

        public string Name
        {
            get => name;
            set
            { 
                SetField(ref name, value);
                this.Greeting = $"Hello, {Name}!";
            }
        }
        public string Greeting { get => greeting; set => SetField(ref greeting, value); }
    }
}
