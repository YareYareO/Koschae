using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class KGR47XPage : Page
{
    public KGR47XViewModel ViewModel
    {
        get;
    }

    public KGR47XPage()
    {
        ViewModel = App.GetService<KGR47XViewModel>();
        InitializeComponent();
    }
}
