using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;
using Koschä.Models.Kostengruppen;
using Koschä.Models;

namespace Koschä.ViewModels;

public class KGR43XViewModel : ObservableRecipient, INavigationAware
{

    public Kostengruppe43X kgr;

    public KGR43XViewModel()
    {
        kgr = Projekt.GetInstance().KGR43X;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }
}
