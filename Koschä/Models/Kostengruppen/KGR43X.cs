using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe43X: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<DoppelSystem> RLTTabelle1;
    [JsonInclude]
    public ObservableCollection<RLTSystem> RLTTabelle2;
    [JsonInclude]
    public ObservableCollection<AktivFlächenSystem> StatischeKalte;
    [JsonInclude]
    public ObservableCollection<RLTSystem> SonderKalte;
    [JsonInclude]
    public ObservableCollection<DoppelDoubleSystem> KalteAnlagen;

    public Kostengruppe43X()
    {
        RLTTabelle1 = new ObservableCollection<DoppelSystem>();
        RLTTabelle2 = new ObservableCollection<RLTSystem>();
        StatischeKalte = new ObservableCollection<AktivFlächenSystem>();
        SonderKalte = new ObservableCollection<RLTSystem>();
        KalteAnlagen = new ObservableCollection<DoppelDoubleSystem>();
    }

    public void Setup()
    {
        RLTTabelle1 = KGRUpdate<DoppelSystem>.SystemTabelleUmBereiche(RLTTabelle1, "431");
        StatischeKalte = KGRUpdate<AktivFlächenSystem>.SystemTabelleUmBereiche(StatischeKalte, "432"); //hier auch bereiche nicht geupdated
        
        if (KalteAnlagen.Count == 0)
        {
            KalteAnlagen = _43XHelper.FügeKälteHinzu();
        }

    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<RLTSystem>.SummeGesamtKostenRLT(RLTTabelle2);
        gesamtkosten += SystemGet<RLTSystem>.SummeAnzahl(SonderKalte);
        gesamtkosten += SystemGet<DoppelDoubleSystem>.SummeGesamtKostenDoppelDoubleSystem(KalteAnlagen);
        return gesamtkosten;
    }

    public void UpdateTabellen()
    {
        UpdateTabelle2();
        UpdateTabelle5();
    }

    private void UpdateTabelle2()
    {
        RLTTabelle2 = _43XHelper.ÜbernehmeZeilenVonTabelle1(RLTTabelle2);
        UpdateKGR420Tab3();
    }

    private void UpdateKGR420Tab3()
    {
        int wärme = _43XHelper.GetSummeDynHeizung();
        if (Projekt.GetInstance().KGR420.Warmebereitstellung.Count > 0)
        {
            Projekt.GetInstance().KGR420.Warmebereitstellung[2].Anzahl = wärme;
            
        }
    }

    private void UpdateTabelle5()
    {
        KalteAnlagen = _43XHelper.UpdateKälte(KalteAnlagen);
        
    }

    public void Tab4AddSystem()
    {
        SonderKalte.Add(new RLTSystem());
    }
    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[3];
        zahlen[0] = SystemGet<RLTSystem>.SummeGesamtKostenRLT(RLTTabelle2).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[1] = SystemGet<RLTSystem>.SummeAnzahl(SonderKalte).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[2] = SystemGet<DoppelDoubleSystem>.SummeGesamtKostenDoppelDoubleSystem(KalteAnlagen).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }

}
