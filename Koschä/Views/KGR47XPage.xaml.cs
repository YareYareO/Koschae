using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

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
        GetUpdatedGesamtkosten();
    }

    private void ButtonTab3_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab3AddSystem();
    }

    private void ButtonTab1_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab1AddSystem();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        GetUpdatedGesamtkosten();
    }

    private void GetUpdatedGesamtkosten()
    {
        string[] zahlen = ViewModel.kgr.UpdateGesamtKosten();
        Sprinkleranlage.Text = zahlen[0];
        Feuerloschanlage.Text = zahlen[1];
        Sonstiges.Text = zahlen[2];
    }
}
