using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;

public partial class AdaptivSystem: SystemTeil, IAdaptivSystem
{

    [ObservableProperty]
    private string systemname;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int wattproM;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int preisProkW;

    public int LeistungGesamt => (int) Math.Ceiling( (double) (WattproM) * (double) (Anzahl) / 1000.0);

    public new int TotalPreis => WirdMitMeterBerechnet() ? (Anzahl * Preis) : (LeistungGesamt * PreisProkW);

    public AdaptivSystem()
    {
        Name = "???";
        Anzahl = 0;
        Preis = 0;
        Systemname = string.Empty;
        systemname = string.Empty;
        WattproM = 0;
        PreisProkW = 0;
    }
    public AdaptivSystem(Bereich bereich, int wattp)
    {
        Name = bereich.Name;
        Anzahl = bereich.Anzahl;
        Preis = 0;
        WattproM = wattp;
        Systemname = string.Empty;
        systemname = string.Empty;
        PreisProkW = 0;
    }
    private bool WirdMitMeterBerechnet()
    {
        return (PreisProkW == 0);
    }
}
