using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class KGR440Page : Page
{
    public KGR440ViewModel ViewModel
    {
        get;
    }

    public KGR440Page()
    {
        ViewModel = App.GetService<KGR440ViewModel>();
        InitializeComponent();
        GetUpdatedGesamtkosten();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab2AddSystem();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        GetUpdatedGesamtkosten();
    }
    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        Standard.Text = zahlen[0];
        Energie.Text = zahlen[1];
    }
}
