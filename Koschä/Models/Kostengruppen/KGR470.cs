using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe470: IKostengruppe
{
    public ObservableCollection<SystemTeil> Tabelle1; 
    public ObservableCollection<SystemTeil> Tabelle2;
    public ObservableCollection<DoppelSystem> Tabelle3;

    public Kostengruppe470()
    {
        Tabelle1 = new ObservableCollection<SystemTeil>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
        Tabelle3 = new ObservableCollection<DoppelSystem>();
    }

    public void Setup()
    {
        Tabelle2 = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle2, "470");
        if(Tabelle3.Count == 0) Tabelle3 = _470Helper.UpdateTabelle3();

    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle1);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2);
        gesamtkosten += SystemGet<DoppelSystem>.SummeGesamtKosten(Tabelle3);
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
