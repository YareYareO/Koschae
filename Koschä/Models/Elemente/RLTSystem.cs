using CommunityToolkit.Mvvm.ComponentModel;

namespace Koschä.Models.Elemente;
public partial class RLTSystem : SystemTeil
{
    [ObservableProperty]
    private int wrg;

    [ObservableProperty]
    private int dynamischeHeizung;

    [ObservableProperty]
    private int krg;

    [ObservableProperty]
    private int dynamischeKälte;

    public RLTSystem(string n, int a, int p) : base()
    {
        Name = n;
        Anzahl = a;
        Preis = p;
        wrg = 0;
        dynamischeHeizung = 0;
        krg = 0;
        dynamischeKälte = 0;
    }
    public RLTSystem() : base()
    {
        Name = "???";
        Anzahl = 0;
        Preis = 0;
        wrg = 0;
        dynamischeHeizung = 0;
        krg = 0;
        dynamischeKälte = 0;
    }
}
