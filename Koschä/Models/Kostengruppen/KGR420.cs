using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;

namespace Koschä.Models.Kostengruppen;

public class Kostengruppe420: IKostengruppe
{
    public ObservableCollection<AdaptivSystem> Tabelle1
    {
        get; set;
    }
    public ObservableCollection<AdaptivSystem> Tabelle2
    {
        get; set;
    }
    public ObservableCollection<SystemTeil> Tabelle3
    {
        get; set;
    }
    public ObservableCollection<SystemTeil> Tabelle4
    {
        get; set;
    }

    public Kostengruppe420()
    {
        Tabelle1 = new ObservableCollection<AdaptivSystem>();
        Tabelle2 = new ObservableCollection<AdaptivSystem>();
        Tabelle3 = new ObservableCollection<SystemTeil>();
        Tabelle4 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Tabelle1, "420");
        Tabelle2 = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Tabelle2, "420");
        Tabelle3 = _420Helper.SetupTabelle3();
        Tabelle4 = _420Helper.SetupTabelle4();
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<AdaptivSystem>.SummeGesamtKosten(Tabelle1);
        gesamtkosten += SystemGet<AdaptivSystem>.SummeGesamtKosten(Tabelle2);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle3);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle4);
        return gesamtkosten;
    }

    public void UpdateTabelle3()
    {

        Tabelle3[0].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Tabelle1);
        Tabelle3[1].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Tabelle2);
        Tabelle4[0].Anzahl = SystemGet<SystemTeil>.SummeAnzahl(Tabelle3);


    }
}
