
using WarColors.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(DLToolkit.Forms.Controls.FlowListView), typeof(CustomListViewRenderer))]
namespace WarColors.UWP
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (List != null)
            {
                List.SelectionMode = Windows.UI.Xaml.Controls.ListViewSelectionMode.None;
            }
        }
    }
}
