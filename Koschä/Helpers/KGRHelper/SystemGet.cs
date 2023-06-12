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
internal class SystemGet<S> where S : ISystem 
{
    public static int SummeGesamtKosten(ObservableCollection<S> tabelle)
    {
        int kosten = 0;

        foreach (var zeile in tabelle)
        {
            kosten += zeile.GetTotalPreis();
        }
        return kosten;
    }

    public static int SummeAnzahl(ObservableCollection<S> tabelle)
    {
        int summe = 0;

        foreach (var zeile in tabelle)
        {
            summe += zeile.Anzahl;
        }

        return summe;
    }

    

    public static bool IstTabelleLeer(ObservableCollection<S> tabelle)
    {
        return tabelle.Count == 0;
    }
}
