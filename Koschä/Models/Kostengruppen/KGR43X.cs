using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe43X: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<DoppelSystem> Tabelle1
    {
        get; set;
    }
    [JsonInclude]
    public ObservableCollection<RLTSystem> Tabelle2
    {
        get; set;
    }
    [JsonInclude]
    public ObservableCollection<AktivFlächenSystem> Tabelle3
    {
        get; set;
    }
    [JsonInclude]
    public ObservableCollection<RLTSystem> Tabelle4
    {
        get; set;
    }
    [JsonInclude]
    public ObservableCollection<DoppelDoubleSystem> Tabelle5
    {
        get; set;
    }

    public Kostengruppe43X()
    {
        Tabelle1 = new ObservableCollection<DoppelSystem>();
        Tabelle2 = new ObservableCollection<RLTSystem>();
        Tabelle3 = new ObservableCollection<AktivFlächenSystem>();
        Tabelle4 = new ObservableCollection<RLTSystem>();
        Tabelle5 = new ObservableCollection<DoppelDoubleSystem>();
    }

    public void Setup()
    {
        
        Tabelle1 = KGRUpdate<DoppelSystem>.SystemTabelleUmBereiche(Tabelle1, "431");
        Tabelle3 = KGRUpdate<AktivFlächenSystem>.SystemTabelleUmBereiche(Tabelle3, "432");

        if (Tabelle5.Count == 0)
        {
            Tabelle5 = _43XHelper.FügeKälteHinzu();
        }

    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<RLTSystem>.SummeGesamtKosten(Tabelle2);
        gesamtkosten += SystemGet<RLTSystem>.SummeGesamtKosten(Tabelle4);
        gesamtkosten += SystemGet<DoppelDoubleSystem>.SummeGesamtKostenDoppelDoubleSystem(Tabelle5);
        return gesamtkosten;
    }

    public void UpdateTabellen()
    {
        UpdateTabelle2();
        UpdateTabelle5();

    }

    private void UpdateTabelle2()
    {
        Tabelle2 = _43XHelper.ÜbernehmeZeilenVonTabelle1(Tabelle2);
        UpdateKGR420Tab3();
    }

    private void UpdateKGR420Tab3()
    {
        int wärme = _43XHelper.GetSummeDynHeizung();
        if (Projekt.GetInstance().KGR420.Tabelle3.Count > 0)
        {
            Projekt.GetInstance().KGR420.Tabelle3[2].Anzahl = wärme;
        }
    }

    private void UpdateTabelle5()
    {
        Tabelle5 = _43XHelper.UpdateKälte(Tabelle5);
    }

    public void Tab4AddSystem()
    {
        Tabelle4.Add(new RLTSystem());
    }

}
