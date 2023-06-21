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
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.AddAufzug();
        Debug.WriteLine(ViewModel.kgr.Tabelle[0].TotalPreis);
    }
}
