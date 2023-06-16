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
public class Kostengruppe440: IKostengruppe
{
    public ObservableCollection<SystemTeil> Tabelle1;

    public ObservableCollection<SystemTeil> Tabelle2;

    public Kostengruppe440()
    {
        Tabelle1 = new ObservableCollection<SystemTeil>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle1, "440");
        if(Tabelle2.Count == 0) { Tabelle2 = _440Helper.UpdateTabelle2(); }
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle1);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2);
        return gesamtkosten;
    }

    public void Tab2AddSystem()
    {
        Tabelle2.Add(new SystemTeil());
    }
}
