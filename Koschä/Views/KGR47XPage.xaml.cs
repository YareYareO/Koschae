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
    }

    private void ButtonTab3_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab3AddSystem();
    }

    private void ButtonTab1_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab1AddSystem();
    }
}
