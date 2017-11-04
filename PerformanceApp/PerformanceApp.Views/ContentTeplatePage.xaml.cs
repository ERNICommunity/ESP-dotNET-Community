using PerformanceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PerformanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentTeplatePage : ContentPage, INotifyPropertyChanged
    {
        public PersonModel _Person1;
        public PersonModel _Person2;
        public PersonModel _PersonSelected;

        public PersonModel Person1
        {
            get => _Person1;
            set => SetProperty(ref _Person1, value);
        }

        public PersonModel Person2
        {
            get => _Person2;
            set => SetProperty(ref _Person2, value);
        }

        public PersonModel PersonSelected
        {
            get => _PersonSelected;
            set => SetProperty(ref _PersonSelected, value);
        }
        public ContentTeplatePage()
        {
            InitializeComponent();
            this.BindingContext = this;
            Person1 = new PersonModel { Name = "1" };
            Person2 = new PersonModel { Name = "2" };
            PersonSelected = Person1;

            ActionPerson = new Command(method);
        }

        public ICommand ActionPerson;



        public void method()
        {
            var x = this.PersonSelected; 
        }

        private void b1_Clicked(object sender, EventArgs e)
        {
            var x = sender as Button; 
            
            if(x.Text.Equals(Person1.Name))
            {
                PersonSelected = Person1;
            }
            else
            {
                PersonSelected = Person2;
            }


        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage">The storage.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}