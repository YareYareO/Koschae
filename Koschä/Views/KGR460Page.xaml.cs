using System.Diagnostics;
using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class KGR460Page : Page
{
    public KGR460ViewModel ViewModel
    {
        get;
    }

    public KGR460Page()
    {
        ViewModel = App.GetService<KGR460ViewModel>();
        InitializeComponent();
        GetUpdatedGesamtkosten();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.AddAufzug();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        GetUpdatedGesamtkosten();
    }
    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        Aufzuge.Text = zahlen[0];
    }
}
