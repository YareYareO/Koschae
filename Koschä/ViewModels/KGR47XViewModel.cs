using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;
using Koschä.Models;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR47XViewModel : ObservableRecipient, INavigationAware
{
    public Kostengruppe470 kgr;

    public KGR47XViewModel()
    {
        kgr = Projekt.GetInstance().KGR470;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }
}
