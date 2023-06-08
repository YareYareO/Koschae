using Koschä.Models;
using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

public sealed partial class ÜbersichtPage : Page
{
    public ÜbersichtViewModel ViewModel
    {
        get;
    }

    public ÜbersichtPage()
    {
        ViewModel = App.GetService<ÜbersichtViewModel>();
        InitializeComponent();
    }
}
