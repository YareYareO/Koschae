using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Models;
using Koschä.Models.Elemente;

namespace Koschä.ViewModels;

public class ÜbersichtViewModel : ObservableRecipient
{
    public ÜbersichtViewModel()
    {
        KostenAllerGruppen = new ObservableCollection<TabellenElement>();
        fülleTabelle();
        SetGesamtkosten();
    }

    public ObservableCollection<TabellenElement> KostenAllerGruppen;

    private readonly string[] kgrnamen = { "Sanitäranlagen", "Heizungstechnik", "Raumlufttechnik",
                                            "Starkstrom", "FM-Infotechnik", "Förderanlagen",
                                            "Spezifische Anlagen", "GLT/MSR und Sonstiges" };

    public string Gesamtkosten
    {
        get; private set;
    }
    private void fülleTabelle()
    {
        int[] kosten = GetAlleEinzelKosten(Projekt.GetInstance().AlleKostengruppen);
        for (int i = 0; i < kosten.Length; i++)
        {
            KostenAllerGruppen.Add(new TabellenElement(kgrnamen[i], kosten[i]));
        }
    }

    private int[] GetAlleEinzelKosten(IKostengruppe[] kgrs)
    {
        int[] kosten = new int[kgrs.Length];

        for (int i = 0; i < kosten.Length; i++)
        {
            kosten[i] = kgrs[i].GetAlleTabellenkosten();
        }
        return kosten;
    }

    public void SetGesamtkosten()
    {
        int ret = 0;
        foreach (var kostengruppe in KostenAllerGruppen)
        {
            ret += kostengruppe.Anzahl;
        }

        string retstring = ret.ToString("C", CultureInfo.CreateSpecificCulture("de-GER"));
        Gesamtkosten = retstring;
    }

}
