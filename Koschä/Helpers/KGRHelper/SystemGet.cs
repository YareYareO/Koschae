using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using Koschä.Models.Kostengruppen;

namespace Koschä.Helpers.KGRHelper;
internal class SystemGet<S> where S : SystemTeil 
{
    public static int SummeGesamtKosten(ObservableCollection<S> tabelle)
    {
        int kosten = 0;

        foreach (var zeile in tabelle)
        {
            kosten += zeile.TotalPreis;
        }
        return kosten;
    }
    public static int SummeGesamtKostenDoppelSystem(ObservableCollection<DoppelSystem> tabelle) //Existiert weil die generische Methode nicht * zweiterWert macht, nur Anzahl * Preis. Kein Plan warum
    {
        int kosten = 0;

        foreach (var zeile in tabelle)
        {
            kosten += zeile.TotalPreis;
        }
        return kosten;
    }

    public static int SummeGesamtKostenDoppelDoubleSystem(ObservableCollection<DoppelDoubleSystem> tabelle) //Existiert weil die generische Methode nicht * zweiterWert macht, nur Anzahl * Preis. Kein Plan warum
    {
        int kosten = 0;

        foreach (var zeile in tabelle)
        {
            kosten += zeile.TotalPreis;
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

}
