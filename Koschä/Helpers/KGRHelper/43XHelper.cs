using System.Collections.ObjectModel;
using Koschä.Models.Elemente;
using Koschä.Models;

namespace Koschä.Helpers.KGRHelper;
public class _43XHelper
{
    public static void ÜbernehmeZeilenVonTabelle1(ref ObservableCollection<RLTSystem> tabelle)
    {
        foreach (var zeile in Projekt.GetInstance().KGR43X.RLTTabelle1)
        {
            if (!tabelle.Any(system => (system.Name == zeile.Name)) & zeile.TotalPreis != 0)
            {
                tabelle.Add(new RLTSystem(zeile.Name, zeile.TotalPreis, p: 1));
            }
            else if (tabelle.Any(system => (system.Name == zeile.Name)) & zeile.TotalPreis == 0)
            {
                tabelle.Remove(FindRLTSystem(tabelle, zeile.Name));
            }
        }
        return;
    }


    private static RLTSystem FindRLTSystem(ObservableCollection<RLTSystem> tabelle, string s)
    {
        foreach (var zeile in tabelle)
        {
            if (zeile.Name == s)
            {
                return zeile;
            }
        }
        return new RLTSystem();
    }

    public static int GetSummeDynHeizung()
    {
        ObservableCollection<RLTSystem> tabelle = Projekt.GetInstance().KGR43X.RLTTabelle2;

        int summeDynHeizung = 0;

        foreach (var zeile in tabelle)
        {
            summeDynHeizung += zeile.DynamischeHeizung;
        }

        return summeDynHeizung;
    }

    public static int GetSummeDynKälte()
    {
        ObservableCollection<RLTSystem> tabelle1 = Projekt.GetInstance().KGR43X.RLTTabelle2;
        //ObservableCollection<RLTSystem> tabelle2 = Projekt.GetInstance().KGR43X.Tabelle4;

        int summeDynHeizung = 0;

        foreach (var zeile in tabelle1)
        {
            summeDynHeizung += zeile.DynamischeKälte;
        }
        //foreach (var zeile in tabelle2)
        //{
        //    summeDynHeizung += zeile.TotalPreis;
        //}

        return summeDynHeizung;
    }

    public static int GetSummeStatKälte()
    {
        ObservableCollection<AktivFlächenSystem> tabelle = Projekt.GetInstance().KGR43X.StatischeKalte;

        int summeDynHeizung = 0;

        foreach (var zeile in tabelle)
        {
            summeDynHeizung += zeile.LeistungGesamt;
        }

        return summeDynHeizung;
    }

    public static void FügeKälteHinzu(ref ObservableCollection<DoppelDoubleSystem> tabelle)
    {

        DoppelDoubleSystem doppelsystem = new DoppelDoubleSystem("Statische Kälte", a: GetSummeStatKälte(), p: 650, z: 0.8);
        DoppelDoubleSystem doppelsystem2 = new DoppelDoubleSystem("Dynamische Kälte", a: GetSummeDynKälte(), p: 100, z: 0.8);
        DoppelDoubleSystem doppelsystem3 = new DoppelDoubleSystem("Grundlastkälte Turbocor", a: GetSummeStatKälte() + GetSummeDynKälte(), p: 175, z: 1);
        DoppelDoubleSystem doppelsystem4 = new DoppelDoubleSystem("Rückkühlung", a: (int)((GetSummeStatKälte() + GetSummeDynKälte())*(1+1/3.1)), p: 150, z: 1);

        tabelle.Add(doppelsystem);
        tabelle.Add(doppelsystem2);
        tabelle.Add(doppelsystem3);
        tabelle.Add(doppelsystem4);

        return;
    }
    public static void UpdateKälte(ref ObservableCollection<DoppelDoubleSystem> tabelle)
    {
        tabelle[0].Anzahl = GetSummeStatKälte();
        tabelle[1].Anzahl = GetSummeDynKälte();
        tabelle[2].Anzahl = (int) (tabelle[0].Anzahl * tabelle[0].ZweiterWert) + tabelle[1].Anzahl;
        tabelle[3].Anzahl = (int) (tabelle[2].Anzahl * (1 + 1 / 3.1));

        foreach (var item in tabelle)
        {
            item.Preis += 1;
            item.Preis -= 1;
        }

        return;
    }
} 
