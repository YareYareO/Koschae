using System.Collections.ObjectModel;
using Koschä.Models.Elemente;

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

    public static int SummeGesamtKostenRLT(ObservableCollection<RLTSystem> tabelle)
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

    public static int SummeGesamtKostenAdaptivSystem(ObservableCollection<AdaptivSystem> tabelle)
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
