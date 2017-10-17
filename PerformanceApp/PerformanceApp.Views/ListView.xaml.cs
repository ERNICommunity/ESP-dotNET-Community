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
    public partial class ListView : ContentPage
    {
        public ListView()
        {
            InitializeComponent();

            //listView.ItemsSource = new List<Color>
            //{
            //    Color.Black, Color.Blue, Color.Gainsboro, Color.Gold, Color.White, Color.Silver, Color.Yellow,
            //    Color.Green, Color.Red
            //};
        }
    }
}