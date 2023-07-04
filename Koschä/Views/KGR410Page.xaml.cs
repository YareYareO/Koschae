using System.Globalization;
using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class KGR410Page : Page
{
    public KGR410ViewModel ViewModel
    {
        get;
    }

    public KGR410Page()
    {
        ViewModel = App.GetService<KGR410ViewModel>();
        InitializeComponent();
        GetUpdatedGesamtkosten();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.SonstigeAddSystem();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        GetUpdatedGesamtkosten();
    }

    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        Sanitär.Text = zahlen[0];
        Sonstige.Text = zahlen[1];
    }
}
