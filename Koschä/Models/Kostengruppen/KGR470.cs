﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe470: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle1;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle2;
    [JsonInclude]
    public ObservableCollection<DoppelSystem> Tabelle3;

    public Kostengruppe470()
    {
        Tabelle1 = new ObservableCollection<SystemTeil>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
        Tabelle3 = new ObservableCollection<DoppelSystem>();
    }

    public void Setup()
    {
        if(Tabelle2.Count == 0) Tabelle2 = KGRUpdate<SystemTeil>.SystemTabelleUmAlleBereiche(Tabelle2);
        if(Tabelle3.Count == 0) Tabelle3 = _470Helper.UpdateTabelle3();

    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle1);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2);
        gesamtkosten += SystemGet<DoppelSystem>.SummeGesamtKostenDoppelSystem(Tabelle3);
        return gesamtkosten;
    }

    public void Tab1AddSystem()
    {
        Tabelle1.Add(new SystemTeil());
    }

    public void Tab3AddSystem()
    {
        Tabelle3.Add(new DoppelSystem());
    }
}
