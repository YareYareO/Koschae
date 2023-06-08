using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using Koschä.Models;
using System.Diagnostics;

namespace Koschä.Helpers.KGRHelper;
public class _43XHelper
{
    public static ObservableCollection<RLTSystem> ÜbernehmeZeilenVonTabelle1(ObservableCollection<RLTSystem> tabelle)
    {
        foreach (var zeile in Projekt.GetInstance().KGR43X.Tabelle1)
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
        return tabelle;
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
        ObservableCollection<RLTSystem> tabelle = Projekt.GetInstance().KGR43X.Tabelle2;

        int summeDynHeizung = 0;

        foreach (var zeile in tabelle)
        {
            summeDynHeizung += zeile.DynamischeHeizung;
        }

        return summeDynHeizung;
    }

    public static int GetSummeDynKälte()
    {
        ObservableCollection<RLTSystem> tabelle1 = Projekt.GetInstance().KGR43X.Tabelle2;
        ObservableCollection<RLTSystem> tabelle2 = Projekt.GetInstance().KGR43X.Tabelle4;

        int summeDynHeizung = 0;

        foreach (var zeile in tabelle1)
        {
            summeDynHeizung += zeile.DynamischeKälte;
        }
        foreach (var zeile in tabelle2)
        {
            summeDynHeizung += zeile.TotalPreis;
        }

        return summeDynHeizung;
    }

    public static int GetSummeStatKälte()
    {
        ObservableCollection<AktivFlächenSystem> tabelle = Projekt.GetInstance().KGR43X.Tabelle3;

        int summeDynHeizung = 0;

        foreach (var zeile in tabelle)
        {
            summeDynHeizung += zeile.LeistungGesamt;
        }

        return summeDynHeizung;
    }

    public static ObservableCollection<DoppelSystem> FügeKälteHinzu()
    {
        ObservableCollection<DoppelSystem> tabelle = new ObservableCollection<DoppelSystem>();

        DoppelSystem doppelsystem = new DoppelSystem("Statische Kälte", a: GetSummeStatKälte(), p: 650, z: 1);
        DoppelSystem doppelsystem2 = new DoppelSystem("Dynamische Kälte", a: GetSummeDynKälte(), p: 100, z: 1);
        DoppelSystem doppelsystem3 = new DoppelSystem("Grundlastkälte Turbocor", a: GetSummeStatKälte() + GetSummeStatKälte(), p: 175, z: 1);
        DoppelSystem doppelsystem4 = new DoppelSystem("Dynamische Kälte", a: (int)((GetSummeStatKälte() + GetSummeStatKälte())*(1+1/3.1)), p: 150, z: 1);

        tabelle.Add(doppelsystem);
        tabelle.Add(doppelsystem2);
        tabelle.Add(doppelsystem3);
        tabelle.Add(doppelsystem4);

        return tabelle;
    }
    public static ObservableCollection<DoppelSystem> UpdateKälte(ObservableCollection<DoppelSystem> tabelle)
    {
        tabelle[0].Anzahl = GetSummeStatKälte();
        tabelle[1].Anzahl = GetSummeDynKälte();

        return tabelle;
    }
}
