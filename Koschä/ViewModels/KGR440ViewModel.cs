using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Contracts.ViewModels;
using Koschä.Models;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR440ViewModel : ObservableRecipient, INavigationAware
{
    public Kostengruppe440 kgr;

    public KGR440ViewModel()
    {
        kgr = Projekt.GetInstance().KGR440;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom()
    {
    }
}
