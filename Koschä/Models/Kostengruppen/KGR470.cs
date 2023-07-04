using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe470: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Sprinkleranlagen;
    [JsonInclude]
    public ObservableCollection<DoppelSystem> Feuerloschanlagen;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Sonstiges;

    public Kostengruppe470()
    {
        Sonstiges = new ObservableCollection<SystemTeil>();
        Sprinkleranlagen = new ObservableCollection<SystemTeil>();
        Feuerloschanlagen = new ObservableCollection<DoppelSystem>();
    }

    public void Setup()
    {
        if(Sprinkleranlagen.Count == 0) Sprinkleranlagen = KGRUpdate<SystemTeil>.SystemTabelleUmAlleBereiche(Sprinkleranlagen);
        if(Feuerloschanlagen.Count == 0) Feuerloschanlagen = _470Helper.UpdateTabelle3();

    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Sonstiges);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Sprinkleranlagen);
        gesamtkosten += SystemGet<DoppelSystem>.SummeGesamtKostenDoppelSystem(Feuerloschanlagen);
        return gesamtkosten;
    }

    public void Tab1AddSystem()
    {
        Sonstiges.Add(new SystemTeil());
    }

    public void Tab3AddSystem()
    {
        Feuerloschanlagen.Add(new DoppelSystem());
    }

    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[3];
        zahlen[0] = SystemGet<SystemTeil>.SummeGesamtKosten(Sprinkleranlagen).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[1] = SystemGet<DoppelSystem>.SummeGesamtKostenDoppelSystem(Feuerloschanlagen).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[2] = SystemGet<SystemTeil>.SummeGesamtKosten(Sonstiges).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
