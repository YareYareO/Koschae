using System.Diagnostics;
using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;


public sealed partial class KGR43XPage : Page
{
    public KGR43XViewModel ViewModel
    {
        get;
    }

    public KGR43XPage()
    {
        ViewModel = App.GetService<KGR43XViewModel>();
        InitializeComponent();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        ViewModel.kgr.UpdateTabellen();
        
    }

    private void AddButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.FügNeuesSystemHinzu();
    }
}
