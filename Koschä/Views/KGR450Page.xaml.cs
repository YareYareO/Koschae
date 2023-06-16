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
    }

}
