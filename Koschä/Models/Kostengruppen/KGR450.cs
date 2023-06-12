using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;

namespace Koschä.Models.Kostengruppen;

public class Kostengruppe450: IKostengruppe
{
    public ObservableCollection<SystemTeil> Tabelle
    {
        get; set;
    }

    public Kostengruppe450()
    {
        Tabelle = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle, "450");
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle);
        return gesamtkosten;
    }

    public void FügNeuesSystemHinzu()
    {
        Tabelle.Add(new SystemTeil());
    }

}
