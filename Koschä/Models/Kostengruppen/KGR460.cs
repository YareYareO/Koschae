using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json.Serialization;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe460: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<DoppelSystem> Aufzuge;

    public Kostengruppe460()
    {
        Aufzuge = new ObservableCollection<DoppelSystem>();
    }

    public void Setup()
    {
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<DoppelSystem>.SummeGesamtKostenDoppelSystem(Aufzuge);
        return gesamtkosten;
    }

    public void AddAufzug()
    {
        Aufzuge.Add(new DoppelSystem());
    }
    public string[] UpdateGesamtKosten()
    {
        string[] zahlen = new string[1];
        zahlen[0] = SystemGet<DoppelSystem>.SummeGesamtKostenDoppelSystem(Aufzuge).ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        return zahlen;
    }
}
