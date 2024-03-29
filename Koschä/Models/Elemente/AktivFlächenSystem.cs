﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Koschä.Models.Elemente;


public partial class AktivFlächenSystem: AdaptivSystem
{
    
    // Diese Klasse wird nur in der Kostengruppe 43X in der Tabelle Kältetechnische Anlagen benutzt. Wie die geerbten Variabeln, wie anzahl und preis, genutzt werden wird in den kommentaren festgehalten
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    private int preis; // spKälteleistung in watt   

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(LeistungGesamt))]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private double belegungsfaktor;

    public new int TotalPreis => (int) (Anzahl * Belegungsfaktor); // totalpreis == aktive Fläche
    public new int LeistungGesamt => (int) Math.Ceiling(((double) Preis * (double)Anzahl * Belegungsfaktor) / 1000.0); //Kälteleistung in kW

    public AktivFlächenSystem()
    {
        Name = "???";
        Anzahl = 0;
        Preis = 0;
        Systemname = string.Empty;
        Belegungsfaktor = 0.7;
    }
    public AktivFlächenSystem(string n, int a, int p)
    {
        Name = n;
        Anzahl = a;
        Preis = p;
        Systemname = string.Empty;
        Belegungsfaktor = 0.7;
    }
    public AktivFlächenSystem(Bereich bereich, int p)
    {
        Name = bereich.Name;
        Anzahl = bereich.Anzahl;
        Preis = p;
        Systemname = string.Empty;
        Belegungsfaktor = 0.7;
    }
} 
