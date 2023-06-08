using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;
public partial class DoppelSystem: ObservableObject, ISystem
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int anzahl;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int preis;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int zweiterWert;


    public int TotalPreis => anzahl * preis * zweiterWert;

    public DoppelSystem(string n, int a, int p)
    {
        name = n;
        anzahl = a;
        preis = p;
        zweiterWert = 0;
    }
    public DoppelSystem(string n, int a, int p, int z)
    {
        name = n;
        anzahl = a;
        preis = p;
        zweiterWert = z;
    }
}
