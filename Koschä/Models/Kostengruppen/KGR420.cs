using System.Collections.ObjectModel;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Koschä.Models.Kostengruppen;

public class Kostengruppe420: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<AdaptivSystem> Tabelle1;
    [JsonInclude]
    public ObservableCollection<AdaptivSystem> Tabelle2;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle3;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle4;

    public Kostengruppe420()
    {
        Tabelle1 = new ObservableCollection<AdaptivSystem>();
        Tabelle2 = new ObservableCollection<AdaptivSystem>();
        Tabelle3 = new ObservableCollection<SystemTeil>();
        Tabelle4 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        // DIE FLÄCHENWWERTE DER BEREICHE WERDEN NICHT GEUPDATED ???? Nur hier TODO:
        Tabelle1 = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Tabelle1, "420");
        Tabelle2 = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Tabelle2, "420");
        if (Tabelle3.Count == 0) Tabelle3 = _420Helper.SetupTabelle3();
        if (Tabelle4.Count == 0) Tabelle4 = _420Helper.SetupTabelle4();
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<AdaptivSystem>.SummeGesamtKostenAdaptivSystem(Tabelle1);
        gesamtkosten += SystemGet<AdaptivSystem>.SummeGesamtKostenAdaptivSystem(Tabelle2);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle3);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle4);
        return gesamtkosten;
    }

    public void UpdateTabellen() //woanders hin vielleicht
    {
        Tabelle3[0].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Tabelle1);
        Tabelle3[1].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Tabelle2);
        Tabelle3[2].Anzahl = _43XHelper.GetSummeDynHeizung();

        foreach (var zeile in Tabelle3) // damit Totalpreis Updated
        {
            zeile.Preis += 1;
            zeile.Preis -= 1;
        }

        Tabelle4[0].Anzahl = SystemGet<SystemTeil>.SummeAnzahl(Tabelle3);
        foreach (var zeile in Tabelle4)
        {
            zeile.Preis += 1;
            zeile.Preis -= 1;
        }
    }

    public void Tab3AddSystem()
    {
        Tabelle3.Add(new SystemTeil());
    }
    public void Tab4AddSystem()
    {
        Tabelle4.Add(new SystemTeil());
    }
}
