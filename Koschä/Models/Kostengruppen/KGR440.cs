using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe440: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Standard;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Energie;

    public Kostengruppe440()
    {
        Standard = new ObservableCollection<SystemTeil>();
        Energie = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Standard = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Standard, "440");
        if(Energie.Count == 0) { Energie = _440Helper.UpdateTabelle2(); }
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Standard);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Energie);
        return gesamtkosten;
    }

    public void Tab2AddSystem()
    {
        Energie.Add(new SystemTeil());
    }
    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[2];
        zahlen[0] = SystemGet<SystemTeil>.SummeGesamtKosten(Standard).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[1] = SystemGet<SystemTeil>.SummeGesamtKosten(Energie).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
