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
        GetUpdatedGesamtkosten();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        ViewModel.kgr.UpdateTabellen();
        GetUpdatedGesamtkosten();
    }

    private void AddTab3Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab3AddSystem();
    }

    private void AddTab4Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab4AddSystem();
    }

    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        StatischeHeizung.Text = zahlen[0];
        Thermoaktiv.Text = zahlen[1];
        Warmebereitstellung.Text = zahlen[2];
        Warmeerzeugung.Text = zahlen[3];
    }
}
