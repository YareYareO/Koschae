using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Koschä.Models.Elemente;
public partial class DoppelDoubleSystem : SystemTeil
{

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private double zweiterWert;


    public new int TotalPreis => (int) (Anzahl * Preis * zweiterWert);

    public DoppelDoubleSystem(string n, int p)
    {
        Name = n;
        Anzahl = 0;
        Preis = p;
        zweiterWert = 0.0;
    }
    public DoppelDoubleSystem(Bereich bereich, int p)
    {
        Name = bereich.Name;
        Anzahl = bereich.Anzahl;
        Preis = p;
        zweiterWert = 0.0;
    }
    public DoppelDoubleSystem(string n, int a, int p, double z)
    {
        Name = n;
        Anzahl = a;
        Preis = p;
        zweiterWert = z;
    }
    public DoppelDoubleSystem()
    {
        Name = "???";
        Anzahl = 0;
        Preis = 0;
        zweiterWert = 0.0;
    }
}
