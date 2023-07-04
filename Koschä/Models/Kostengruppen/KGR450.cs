using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;

public class Kostengruppe450: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle;

    public Kostengruppe450()
    {
        Tabelle = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle, "450");
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle);
        return gesamtkosten;
    }

    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[1];
        zahlen[0] = SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
