using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;
public partial class AktivFlächenSystem: ObservableObject, IAdaptivSystem
{
    
    // Diese Klasse wird nur in der Kostengruppe 43X in der Tabelle Kältetechnische Anlagen benutzt. Wie die geerbten Variabeln, wie anzahl und preis, genutzt werden wird in den kommentaren festgehalten


    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string systemSpezifikation;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int anzahl; //hier behandelte HNF (Ganze Fläche)

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int preis; // spKälteleistung in watt

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private double belegungsfaktor;

    public int TotalPreis => (int) (anzahl * belegungsfaktor); // totalpreis == aktive Fläche
    public int LeistungGesamt => (int) (preis * anzahl * belegungsfaktor) / 1000; //Kälteleistung in kW

    public AktivFlächenSystem()
    {
        name = "???";
        anzahl = 0;
        preis = 0;
        systemSpezifikation = string.Empty;
        belegungsfaktor = 0.7;
    }
    public AktivFlächenSystem(string n, int a, int p)
    {
        name = n;
        anzahl = a;
        preis = p;
        systemSpezifikation = string.Empty;
        belegungsfaktor = 0.7;
    }
}
