using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class KGR480490Page : Page
{
    public KGR480490ViewModel ViewModel
    {
        get;
    }

    public KGR480490Page()
    {
        ViewModel = App.GetService<KGR480490ViewModel>();
        InitializeComponent();
        GetUpdatedGesamtkosten();
    }

    private void Tabelle1KGR410Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.FügNeuesSystemHinzu();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        GetUpdatedGesamtkosten();
    }

    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        Gewerke.Text = zahlen[0];
        Sonstiges.Text = zahlen[1];
    }
}
