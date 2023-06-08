using System.Diagnostics;
using Koschä.Helpers.KGRHelper;
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
        UpdateText();
    }

    private void Tabelle1KGR410Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.FügNeuesSystemHinzu();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        UpdateText();
        
    }

    private void UpdateText()
    {
        Kosten.Text = ViewModel.UpdatedText();
    }
}
