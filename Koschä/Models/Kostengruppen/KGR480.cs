using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json.Serialization;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe480490: IKostengruppe
{
    
    public ObservableCollection<ProzentSystem> Gewerke;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Sonstiges;

    public Kostengruppe480490()
    {
        Gewerke = new ObservableCollection<ProzentSystem>();
        Sonstiges = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        if (Gewerke.Count == 0) Gewerke = _480Helper.SetupTabelle();
        else Gewerke = _480Helper.UpdateTabelle(Gewerke);
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<ProzentSystem>.SummeGesamtKosten(Gewerke)/100;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Sonstiges);
        return gesamtkosten;
    }

    public void FügNeuesSystemHinzu()
    {
        Sonstiges.Add(new SystemTeil());
    }

    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[2];
        zahlen[0] = (SystemGet<ProzentSystem>.SummeGesamtKosten(Gewerke)/100).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        zahlen[1] = SystemGet<SystemTeil>.SummeGesamtKosten(Sonstiges).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
