using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe480490: IKostengruppe
{
    
    public ObservableCollection<ProzentSystem> Tabelle1;
    [JsonInclude]
    public ObservableCollection<SystemTeil> Tabelle2;

    public Kostengruppe480490()
    {
        Tabelle1 = new ObservableCollection<ProzentSystem>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        if (Tabelle1.Count == 0) Tabelle1 = _480Helper.SetupTabelle();
        else Tabelle1 = _480Helper.UpdateTabelle(Tabelle1);
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<ProzentSystem>.SummeGesamtKosten(Tabelle1)/100;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2);
        return gesamtkosten;
    }

    public void FügNeuesSystemHinzu()
    {
        Tabelle2.Add(new SystemTeil());
    }
}
