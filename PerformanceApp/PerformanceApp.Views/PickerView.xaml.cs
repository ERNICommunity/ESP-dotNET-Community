using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PerformanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerView : ContentPage
    {
        public PickerView()
        {
            InitializeComponent();
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (entry == null)
            {
                return;
            }

            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1)
            {
                return;
            }

            var selectedItem = picker.Items[selectedIndex];
            var propertyInfo = typeof(Keyboard).GetRuntimeProperty(selectedItem);
            entry.Keyboard = (Keyboard)propertyInfo.GetValue(null);
        }
    }
}