using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class KGR450Page : Page
{
    public KGR450ViewModel ViewModel
    {
        get;
    }

    public KGR450Page()
    {
        ViewModel = App.GetService<KGR450ViewModel>();
        InitializeComponent();
        UpdateTotalText();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        UpdateTotalText();
    }

    private void UpdateTotalText()
    {
        Total.Text = ViewModel.UpdatedText();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.FügNeuesSystemHinzu();
    }
}
