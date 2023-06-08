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
    public ObservableCollection<IAdaptivSystem> Tabelle1
    {
        get; set;
    }
    public ObservableCollection<IAdaptivSystem> Tabelle2
    {
        get; set;
    }
    public ObservableCollection<ISystem> Tabelle3
    {
        get; set;
    }
    public ObservableCollection<ISystem> Tabelle4
    {
        get; set;
    }

    public Kostengruppe420()
    {
        Tabelle1 = new ObservableCollection<IAdaptivSystem>();
        Tabelle2 = new ObservableCollection<IAdaptivSystem>();
        Tabelle3 = new ObservableCollection<ISystem>();
        Tabelle4 = new ObservableCollection<ISystem>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate.AdaptivsystemTabelleUmBereiche(Tabelle1, "420");
        Tabelle2 = KGRUpdate.AdaptivsystemTabelleUmBereiche(Tabelle2, "420");
        Tabelle3 = _420Helper.SetupTabelle3();
        Tabelle4 = _420Helper.SetupTabelle4();
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += KGRGet.SummeGesamtKostenAdaptiv(Tabelle1);
        gesamtkosten += KGRGet.SummeGesamtKostenAdaptiv(Tabelle2);
        gesamtkosten += KGRGet.SummeGesamtKostenEinfach(Tabelle3);
        gesamtkosten += KGRGet.SummeGesamtKostenEinfach(Tabelle4);
        return gesamtkosten;
    }

    public void UpdateTabelle3()
    {

        Tabelle3[0].Anzahl = KGRGet.SummeKW(Tabelle1);
        Tabelle3[1].Anzahl = KGRGet.SummeKW(Tabelle2);
        Tabelle4[0].Anzahl = KGRGet.SummeAnzahl(Tabelle3);


    }
}
