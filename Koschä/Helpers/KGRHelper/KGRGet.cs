using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using Koschä.Models.Kostengruppen;

namespace Koschä.Helpers.KGRHelper;
internal class KGRGet
{
    public static int SummeGesamtKostenEinfach(ObservableCollection<ISystem> tabelle)
    {
        int kosten = 0;

        foreach (var zeile in tabelle)
        {
            kosten += zeile.GetTotalPreis();
        }
        return kosten;
    }

    public static int SummeGesamtKostenAdaptiv(ObservableCollection<IAdaptivSystem> tabelle)
    {
        int kosten = 0;

        foreach (var zeile in tabelle)
        {
            kosten += zeile.GetTotalPreis();
        }
        return kosten;
    }

    public static int SummeAnzahl(ObservableCollection<ISystem> tabelle)
    {
        int summe = 0;

        foreach (var zeile in tabelle)
        {
            summe += zeile.Anzahl;
        }

        return summe;
    }

    public static int SummeKW(ObservableCollection<IAdaptivSystem> tabelle)
    {
        int kW = 0;

        foreach (var zeile in tabelle)
        {
            kW += zeile.LeistungGesamt;
        }
        return kW;
    }

    public static bool IstTabelleLeer(ObservableCollection<DoppelSystem> tabelle)
    {
        return tabelle.Count == 0;
    }
    public static bool IstTabelleLeer(ObservableCollection<AktivFlächenSystem> tabelle)
    {
        return tabelle.Count == 0;
    }
}
