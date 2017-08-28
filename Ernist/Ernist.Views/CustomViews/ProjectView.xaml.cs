using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ernist.Views.CustomViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProjectView : ContentView
	{
		public ProjectView ()
		{
			InitializeComponent ();
		}
	}
}