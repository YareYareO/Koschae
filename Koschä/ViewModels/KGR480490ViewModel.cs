using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;
using Koschä.Models;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR480490ViewModel : ObservableRecipient, INavigationAware
{
    public Kostengruppe480490 kgr;

    public KGR480490ViewModel()
    {
        kgr = Projekt.GetInstance().KGR480490;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }
}
