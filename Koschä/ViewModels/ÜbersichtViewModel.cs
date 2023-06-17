using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Koschä.Helpers;
using Koschä.Helpers.KGRHelper;
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

    private readonly string[] kgrnamen = { "KGR 410", "KGR 420", "KGR 43X", "KGR 440", "KGR 450", "KGR 460", "KGR 470", "KGR 480" };

    public int Gesamtkosten
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
        Gesamtkosten = ret;
    }

}
