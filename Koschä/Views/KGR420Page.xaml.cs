using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;
public sealed partial class KGR420Page : Page
{
    public KGR420ViewModel ViewModel
    {
        get;
    }

    public KGR420Page()
    {
        ViewModel = App.GetService<KGR420ViewModel>();
        InitializeComponent();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        ViewModel.kgr.UpdateTabelle3();
    }

    private void AddTab3Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab3AddSystem();
    }

    private void AddTab4Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab4AddSystem();
    }
}
