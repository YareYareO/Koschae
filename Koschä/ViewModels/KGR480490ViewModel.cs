using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Koschä.Contracts.ViewModels;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Models;

namespace Koschä.ViewModels;

public class KGR480490ViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public KGR480490ViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
