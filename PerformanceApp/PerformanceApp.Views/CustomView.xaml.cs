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
	public partial class CustomView : ContentView
	{
		public CustomView ()
		{
			InitializeComponent ();
		}

        public string TitleText { get; set; }

        private static BindableProperty titleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(CustomView),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: titleTextPropertyChanged);


        private static void titleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomView)bindable;
            control.title.Text = newValue.ToString();
        }


        public static BindableProperty ImageProperty = BindableProperty.Create(
                                                        propertyName: "Image",
                                                        returnType: typeof(string),
                                                        declaringType: typeof(CustomView),
                                                        defaultValue: "",
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: ImageSourcePropertyChanged);

        public string Image
        {
            get { return base.GetValue(ImageProperty).ToString(); }
            set { base.SetValue(ImageProperty, value); }
        }

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomView)bindable;
            control.image.Source = ImageSource.FromFile(newValue.ToString());
        }
    }
}