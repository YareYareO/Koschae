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
    public ObservableCollection<ISystem> Tabelle
    {
        get; set;
    }

    public Kostengruppe450()
    {
        Tabelle = new ObservableCollection<ISystem>();
    }

    public void Setup()
    {
        Tabelle = KGRUpdate.SystemTabelleUmBereiche(Tabelle, "450");
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += KGRGet.SummeGesamtKostenEinfach(Tabelle);
        return gesamtkosten;
    }

    public void FügNeuesSystemHinzu()
    {
        Tabelle.Add(new SystemTeil());
    }

}
