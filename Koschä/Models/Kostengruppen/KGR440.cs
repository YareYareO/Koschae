using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe440: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle1;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle2;

    public Kostengruppe440()
    {
        Tabelle1 = new ObservableCollection<SystemTeil>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle1, "440");
        if(Tabelle2.Count == 0) { Tabelle2 = _440Helper.UpdateTabelle2(); }
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle1);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2);
        return gesamtkosten;
    }

    public void Tab2AddSystem()
    {
        Tabelle2.Add(new SystemTeil());
    }
}
