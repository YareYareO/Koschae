using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;

namespace Koschä.Helpers.KGRHelper;
public class ConvertTabelleTo
{
    public static ObservableCollection<ISystem> ISystemTabelle(ObservableCollection<DoppelSystem> anfangstabelle)
    {   
        //Von Doppel To System
        ObservableCollection<ISystem> returntabelle = new ObservableCollection<ISystem>();

        foreach (var zeile in anfangstabelle)
        {
            returntabelle.Add(zeile);
        }

        return returntabelle;
    }

    public static ObservableCollection<DoppelSystem> DoppelSystemTabelle(ObservableCollection<ISystem> anfangstabelle)
    {
        //Von System To Doppel
        ObservableCollection<DoppelSystem> returntabelle = new ObservableCollection<DoppelSystem>();

        foreach (var zeile in anfangstabelle)
        {
            returntabelle.Add(new DoppelSystem(n: zeile.Name, a: zeile.Anzahl, p: zeile.Preis));
        }

        return returntabelle;
    }

    public static ObservableCollection<ISystem> ISystemTabelleVonAktiv(ObservableCollection<AktivFlächenSystem> anfangstabelle)
    {
        //Von AktivFläschen to System
        ObservableCollection<ISystem> returntabelle = new ObservableCollection<ISystem>();

        foreach (var zeile in anfangstabelle)
        {
            returntabelle.Add(zeile);
        }

        return returntabelle;
    }

    public static ObservableCollection<AktivFlächenSystem> AktivSystemTabelleVonISystem(ObservableCollection<ISystem> anfangstabelle)
    {
        //Von System To AktivFläschen
        ObservableCollection<AktivFlächenSystem> returntabelle = new ObservableCollection<AktivFlächenSystem>();

        foreach (var zeile in anfangstabelle)
        {
            returntabelle.Add(new AktivFlächenSystem(n: zeile.Name, a: zeile.Anzahl, p: zeile.Preis));
        }

        return returntabelle;
    }
}
