using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Contracts.ViewModels;
using Koschä.Models;
using Koschä.Models.Kostengruppen;

namespace Koschä.ViewModels;

public class KGR410ViewModel : ObservableRecipient, INavigationAware
{
    public Kostengruppe410 kgr;

    public KGR410ViewModel()
    {
        kgr = Projekt.GetInstance().KGR410;
    }

    public void OnNavigatedTo(object parameter)
    {
        kgr.Setup();
    }

    public void OnNavigatedFrom() {}

}
