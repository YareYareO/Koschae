using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe43X: IKostengruppe
{
    public ObservableCollection<DoppelSystem> Tabelle1
    {
        get; set;
    }

    public ObservableCollection<RLTSystem> Tabelle2
    {
        get; set;
    }

    public ObservableCollection<AktivFlächenSystem> Tabelle3
    {
        get; set;
    }
    public ObservableCollection<RLTSystem> Tabelle4
    {
        get; set;
    }
    public ObservableCollection<DoppelSystem> Tabelle5
    {
        get; set;
    }

    public Kostengruppe43X()
    {
        Tabelle1 = new ObservableCollection<DoppelSystem>();
        Tabelle2 = new ObservableCollection<RLTSystem>();
        Tabelle3 = new ObservableCollection<AktivFlächenSystem>();
        Tabelle4 = new ObservableCollection<RLTSystem>();
        Tabelle5 = new ObservableCollection<DoppelSystem>();
    }

    public void Setup()
    {
        
        Tabelle1 = ConvertTabelleTo.DoppelSystemTabelle(KGRUpdate.SystemTabelleUmBereiche(ConvertTabelleTo.ISystemTabelle(Tabelle1), "431"));
        Tabelle3 = ConvertTabelleTo.AktivSystemTabelleVonISystem(KGRUpdate.SystemTabelleUmBereiche(ConvertTabelleTo.ISystemTabelleVonAktiv(Tabelle3), "432"));

        if (KGRGet.IstTabelleLeer(Tabelle5))
        {
            Tabelle5 = _43XHelper.FügeKälteHinzu();
            
        }

    }

    public int GetAlleTabellenkosten()
    {
        return 0;
    }

    public void UpdateTabellen()
    {
        UpdateTabelle2();
        UpdateTabelle5();
    }

    private void UpdateTabelle2()
    {
        Tabelle2 = _43XHelper.ÜbernehmeZeilenVonTabelle1(Tabelle2);
    }

    private void UpdateTabelle5()
    {
        Tabelle5 = _43XHelper.UpdateKälte(Tabelle5);
    }

    public void FügNeuesSystemHinzu()
    {
        Tabelle4.Add(new RLTSystem());
    }

}
