using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;
using Koschä.Models;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR460ViewModel : ObservableRecipient, INavigationAware
{
    public Kostengruppe460 kgr;
    public KGR460ViewModel()
    {
        kgr = Projekt.GetInstance().KGR460;
    }

    public void OnNavigatedTo(object parameter)
    {
       // kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }
}
