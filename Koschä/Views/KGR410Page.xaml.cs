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
        
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.kgr.Tab2AddSystem();
    }

}
