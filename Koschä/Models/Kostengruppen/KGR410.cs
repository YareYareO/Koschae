using System.Collections.ObjectModel;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Koschä.Models.Kostengruppen;
public partial class Kostengruppe410 : IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Sanitar;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Sonstiges;

    public Kostengruppe410() 
    {
        Sanitar = new ObservableCollection<SystemTeil>();
        Sonstiges = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Sanitar = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Sanitar, "410");
        if(Sonstiges.Count == 0) Sonstiges = _410Helper.SetupTabelle2(Sonstiges);

    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Sanitar);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Sonstiges);
        return gesamtkosten;
    }

    public void SonstigeAddSystem()
    {
        Sonstiges.Add(new SystemTeil());
    }

    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[2];
        zahlen[0] = SystemGet<SystemTeil>.SummeGesamtKosten(Sanitar).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[1] = SystemGet<SystemTeil>.SummeGesamtKosten(Sonstiges).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
