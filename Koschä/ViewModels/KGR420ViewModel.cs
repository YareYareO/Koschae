using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Contracts.ViewModels;
using Koschä.Models;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR420ViewModel : ObservableRecipient, INavigationAware
{

    public Kostengruppe420 kgr;

    public KGR420ViewModel()
    {
        kgr = Projekt.GetInstance().KGR420;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }
}
