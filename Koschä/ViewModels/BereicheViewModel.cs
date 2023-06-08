using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Contracts.ViewModels;
using Koschä.Helpers;
using Koschä.Models;
using Koschä.Models.Elemente;

namespace Koschä.ViewModels;

public class BereicheViewModel : ObservableRecipient, INavigationAware
{
    public ObservableCollection<Bereich> Source { get; set; }

    public BereicheViewModel()
    {
        Source = new ObservableCollection<Bereich>();
    }

    public void OnNavigatedTo(object parameter)
    {
        Source = Projekt.GetInstance().AlleBereiche;
    }

    public void FügNeuenBereichHinzu()
    {
        Source.Add(new Bereich());
        Debug.WriteLine(Projekt.GetInstance().AlleBereiche.Count);
    }
    public void OnNavigatedFrom()
    {
    }

}
