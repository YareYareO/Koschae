using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;
using Koschä.Models;
using Koschä.Models.Interface;
using Koschä.Models.Elemente;
using Koschä.Models.Kostengruppen;
using Koschä.Helpers.KGRHelper;

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

    public void FügNeuesSystemHinzu()
    {
        kgr.FügNeuesSystemHinzu();
    }

    public string UpdatedText()
    {
        return kgr.UpdatedText();
    }
}
