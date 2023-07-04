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
        GetUpdatedGesamtkosten();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        ViewModel.kgr.UpdateTabellen();
        GetUpdatedGesamtkosten();
    }

    private void AddButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab4AddSystem();
    }
    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        RLT2.Text = zahlen[0];
        SonderKalte.Text = zahlen[1];
        KalteAnlagen.Text = zahlen[2];
    }
}
