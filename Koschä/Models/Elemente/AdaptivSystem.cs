using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;

partial class AdaptivSystem: ObservableObject, IAdaptivSystem
{
    [ObservableProperty]
    private string name;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int anzahl;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int preis;

    [ObservableProperty]
    private string systemname;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int wattproM;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int preisProkW;

    public int LeistungGesamt => (WattproM * anzahl)/1000;

    public int TotalPreis => WirdMitMeterBerechnet() ? (anzahl * preis) : (LeistungGesamt * preisProkW);

    public AdaptivSystem()
    {
        name = "???";
        anzahl = 0;
        preis = 0;
        systemname = string.Empty;
        WattproM = 0;
    }
    public AdaptivSystem(Bereich bereich, int meterp, int wattp)
    {
        name = bereich.Name;
        anzahl = bereich.Anzahl;
        preis = meterp;
        wattproM = wattp;
        systemname = string.Empty;
    }
    private bool WirdMitMeterBerechnet()
    {
        return (preisProkW == 0);
    }
}
