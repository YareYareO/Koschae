using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;
using Koschä.Helpers.KGRHelper;
using Koschä.Models;
using Koschä.Models.Elemente;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR450ViewModel : ObservableRecipient, INavigationAware
{

    public Kostengruppe450 kgr;

    public KGR450ViewModel()
    {
        kgr = Projekt.GetInstance().KGR450;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }

    public string UpdatedText()
    {
        return SystemGet<SystemTeil>.SummeGesamtKosten(kgr.Tabelle).ToString();
    }

}
