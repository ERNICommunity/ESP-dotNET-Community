using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System;
using WarColors.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarColors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : MasterDetailPage
    {
        public MasterView()
        {
            InitializeComponent();

            ColumnMasterView.ListView.ItemSelected += ViewCellTapped;
        }

        private void ViewCellTapped(object sender, EventArgs e)
        {
            if (ColumnMasterView.ListView.SelectedItem != null)
            {
                var vm = IoC.Get<ProjectListViewModel>();

                var page = ViewLocator.LocateForModel(vm, null, null) as Page;
                page.BindingContext = vm;
                (Detail as NavigationPage).PushAsync(page);

                ColumnMasterView.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}