﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Koschä.Models.Elemente;
public partial class DoppelSystem: SystemTeil
{

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TotalPreis))]
    private int zweiterWert;


    public new int TotalPreis => Anzahl * Preis * ZweiterWert;

    public DoppelSystem(string n, int p)
    {
        Name = n;
        Anzahl = 0;
        Preis = p;
        zweiterWert = 0;
    }
    public DoppelSystem(Bereich bereich, int p)
    {
        Name = bereich.Name;
        Anzahl = bereich.Anzahl;
        Preis = p;
        zweiterWert = 0;
    }
    public DoppelSystem(string n, int a, int p, int z)
    {
        Name = n;
        Anzahl = a;
        Preis = p;
        zweiterWert = z;
    }
    public DoppelSystem()
    {
        Name = "???";
        Anzahl = 0;
        Preis = 0;
        zweiterWert = 0;
    }
}
