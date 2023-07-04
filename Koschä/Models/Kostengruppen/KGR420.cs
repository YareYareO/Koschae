using System.Collections.ObjectModel;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Globalization;

namespace Koschä.Models.Kostengruppen;

public class Kostengruppe420: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<AdaptivSystem> Statisches;
    [JsonInclude]
    public ObservableCollection<AdaptivSystem> Thermoaktives;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Warmebereitstellung;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Warmeerzeugung;

    public Kostengruppe420()
    {
        Statisches = new ObservableCollection<AdaptivSystem>();
        Thermoaktives = new ObservableCollection<AdaptivSystem>();
        Warmebereitstellung = new ObservableCollection<SystemTeil>();
        Warmeerzeugung = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        // DIE FLÄCHENWWERTE DER BEREICHE WERDEN NICHT GEUPDATED ???? Nur hier TODO:
        Statisches = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Statisches, "420");
        Thermoaktives = KGRUpdate<AdaptivSystem>.SystemTabelleUmBereiche(Thermoaktives, "420");
        if (Warmebereitstellung.Count == 0) Warmebereitstellung = _420Helper.SetupTabelle3();
        if (Warmeerzeugung.Count == 0) Warmeerzeugung = _420Helper.SetupTabelle4();
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<AdaptivSystem>.SummeGesamtKostenAdaptivSystem(Statisches);
        gesamtkosten += SystemGet<AdaptivSystem>.SummeGesamtKostenAdaptivSystem(Thermoaktives);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Warmebereitstellung);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Warmeerzeugung);
        return gesamtkosten;
    }

    public void UpdateTabellen() //woanders hin vielleicht
    {
        Warmebereitstellung[0].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Statisches);
        Warmebereitstellung[1].Anzahl = AdaptivSysGet<AdaptivSystem>.SummeKW(Thermoaktives);
        Warmebereitstellung[2].Anzahl = _43XHelper.GetSummeDynHeizung();

        foreach (var zeile in Warmebereitstellung) // damit Totalpreis Updated
        {
            zeile.Preis += 1;
            zeile.Preis -= 1;
        }

        Warmeerzeugung[0].Anzahl = SystemGet<SystemTeil>.SummeAnzahl(Warmebereitstellung);
        foreach (var zeile in Warmeerzeugung)
        {
            zeile.Preis += 1;
            zeile.Preis -= 1;
        }
    }

    public void Tab3AddSystem()
    {
        Warmebereitstellung.Add(new SystemTeil());
    }
    public void Tab4AddSystem()
    {
        Warmeerzeugung.Add(new SystemTeil());
    }
    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[4];
        zahlen[0] = SystemGet<AdaptivSystem>.SummeGesamtKostenAdaptivSystem(Statisches).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[1] = SystemGet<AdaptivSystem>.SummeGesamtKostenAdaptivSystem(Thermoaktives).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[2] = SystemGet<SystemTeil>.SummeGesamtKosten(Warmebereitstellung).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[3] = SystemGet<SystemTeil>.SummeGesamtKosten(Warmeerzeugung).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
