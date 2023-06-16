using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;

public partial class AdaptivSystem: SystemTeil, IAdaptivSystem
{

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int anzahl;

    [ObservableProperty]
    private string systemname;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int wattproM;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int preisProkW;

    public int LeistungGesamt => (int) Math.Ceiling( (double) (WattproM * anzahl / 1000));

    public new int TotalPreis => WirdMitMeterBerechnet() ? (anzahl * Preis) : (LeistungGesamt * preisProkW);

    public AdaptivSystem()
    {
        Name = "???";
        anzahl = 0;
        Preis = 0;
        systemname = string.Empty;
        WattproM = 0;
        preisProkW = 0;
    }
    public AdaptivSystem(Bereich bereich, int wattp)
    {
        Name = bereich.Name;
        anzahl = bereich.Anzahl;
        Preis = 0;
        wattproM = wattp;
        systemname = string.Empty;
        preisProkW = 0;
    }
    private bool WirdMitMeterBerechnet()
    {
        return (preisProkW == 0);
    }
}
