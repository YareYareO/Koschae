using System.Collections.ObjectModel;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using System.Text.Json.Serialization;

namespace Koschä.Models.Kostengruppen;

public class Kostengruppe420: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<AdaptivSystem> Tabelle1
    {
        get; set;
    }
    [JsonInclude]
    public ObservableCollection<AdaptivSystem> Tabelle2
    {
        get; set;
    }
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle3
    {
        get; set;
    }
    [JsonInclude]
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
        // DIE FLÄCHENWWERTE DER BEREICHE WERDEN NICHT GEUPDATED ???? Nur hier TODO:
        Tabelle1 = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Tabelle1, "420");
        Tabelle2 = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Tabelle2, "420");
        if(Tabelle3.Count == 0) Tabelle3 = _420Helper.SetupTabelle3();
        if (Tabelle4.Count == 0) Tabelle4 = _420Helper.SetupTabelle4();
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

    public void UpdateTabelle3() //woanders hin vielleicht
    {
        Tabelle3[0].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Tabelle1);
        Tabelle3[1].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Tabelle2);

        Tabelle4[0].Anzahl = SystemGet<SystemTeil>.SummeAnzahl(Tabelle3);
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
