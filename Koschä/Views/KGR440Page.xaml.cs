using Koschä.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class KGR440Page : Page
{
    public KGR440ViewModel ViewModel
    {
        get;
    }

    public KGR440Page()
    {
        ViewModel = App.GetService<KGR440ViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab2AddSystem();
    }
}
