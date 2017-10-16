using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PerformanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputView : ContentPage
    {
        public InputView()
        {
            InitializeComponent();
        }

        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            inputLabel.Text = e.NewTextValue;
        }
    }
}