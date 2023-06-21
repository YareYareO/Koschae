using System.Collections.ObjectModel;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using System.Text.Json.Serialization;

namespace Koschä.Models.Kostengruppen;
public partial class Kostengruppe410 : IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle1;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle2;

    public Kostengruppe410() 
    {
        Tabelle1 = new ObservableCollection<SystemTeil>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle1, "410");
        if(Tabelle2.Count == 0) Tabelle2 = _410Helper.SetupTabelle2(Tabelle2);
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
