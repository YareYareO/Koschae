using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;


public sealed partial class BereichePage : Page
{
    public BereicheViewModel ViewModel
    {
        get;
    }

    public BereichePage()
    {
        ViewModel = App.GetService<BereicheViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.FügNeuenBereichHinzu();
    }

    private void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
       // ViewModel.SpeichereTabelle();
    }
}
