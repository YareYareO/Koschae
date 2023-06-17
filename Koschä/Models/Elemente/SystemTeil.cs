using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models.Interface;
using CommunityToolkit.Mvvm;

namespace Koschä.Models.Elemente;
public partial class SystemTeil: ObservableObject, ISystem
{
    [ObservableProperty]
    private string name;
    

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int anzahl;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int preis;

    public int TotalPreis => anzahl * preis;
    
    public SystemTeil()
    {
        name = "???";
        anzahl = 0;
        preis = 0;
    }
    public SystemTeil(string n, int p)
    {
        name = n;
        anzahl = 0;
        preis = p;
    }

    public SystemTeil(Bereich bereich, int p)
    {
        name = bereich.Name;
        anzahl = bereich.Anzahl;
        preis = p;
    }
    public SystemTeil(Bereich bereich)
    {
        name = bereich.Name;
        anzahl = bereich.Anzahl;
        preis = 0;
    }
    public SystemTeil(string n, int a, int p)
    {
        name = n;
        anzahl = a;
        preis = p;
    }

}
