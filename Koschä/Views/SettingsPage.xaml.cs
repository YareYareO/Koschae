using Koschä.Models;
using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
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
}
