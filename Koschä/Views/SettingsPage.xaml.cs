using Koschä.Helpers;
using Koschä.Models;
using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;


public sealed partial class SettingsPage : Page
{
    private readonly Projekt projektReferenz = Projekt.GetInstance();
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    private void ProjektName_TextChanged(object sender, TextChangedEventArgs e)
    {
        projektReferenz.Projektname = ProjektName.Text;
    }

    private async void LadeButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        await SpeicherHelper.LadeDaten();
    }
}
