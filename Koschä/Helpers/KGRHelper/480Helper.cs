using System.Collections.ObjectModel;
using Koschä.Models;
using Koschä.Models.Elemente;

namespace Koschä.Helpers.KGRHelper;
public class _480Helper
{
    public static void SetupTabelle(ref ObservableCollection<ProzentSystem> tabelle)
    {

        string[] namen = { "Sanitärtechnik", "Heizungstechnik", "Lüftungs- u. Kältetechnik", "Starkstromtechnik", "Fernmeldetechnik",
                            "Förderanlagen", "Nutzungsspezifische Anlagen"};

        IKostengruppe[] kgrref = Projekt.GetInstance().AlleKostengruppen;
        
        int[] preise = new int[7];
        for (int i = 0; i < preise.Length; i++)
        {
            
            preise[i] = kgrref[i].GetAlleTabellenkosten();
            //Für KGR420 und 43X werden nicht alle Tabellen in die Berechnung reingenommen, diese Werte werden hier abgezogen
            if (i == 1) preise[i] -= SystemGet<SystemTeil>.SummeGesamtKosten(Projekt.GetInstance().KGR420.Warmeerzeugung);
            if (i == 2)
            {
                if (Projekt.GetInstance().KGR43X.KalteAnlagen.Count >= 4)
                {
                    preise[i] -= SystemGet<RLTSystem>.SummeAnzahl(Projekt.GetInstance().KGR43X.SonderKalte);
                    preise[i] -= Projekt.GetInstance().KGR43X.KalteAnlagen[2].TotalPreis;
                    preise[i] -= Projekt.GetInstance().KGR43X.KalteAnlagen[3].TotalPreis;
                }
                
            }
        }

        int[] prozente = { 2, 5, 10, 2, 2, 2, 2};

        for(int i = 0;i < preise.Length;i++)
        {
            ProzentSystem system = new ProzentSystem(namen[i], a: prozente[i], p: preise[i]);
            tabelle.Add(system);
        }

        return;

    }

    public static void UpdateTabelle(ref ObservableCollection<ProzentSystem> tabelle)
    {

        IKostengruppe[] kgrref = Projekt.GetInstance().AlleKostengruppen;

        for (int i = 0; i < kgrref.Length-1; i++)
        {
            tabelle[i].Preis = kgrref[i].GetAlleTabellenkosten();
            if (i == 1) tabelle[i].Preis -= SystemGet<SystemTeil>.SummeGesamtKosten(Projekt.GetInstance().KGR420.Warmeerzeugung);
            if (i == 2)
            {
                if (Projekt.GetInstance().KGR43X.KalteAnlagen.Count >= 4)
                {
                    tabelle[i].Preis -= SystemGet<RLTSystem>.SummeAnzahl(Projekt.GetInstance().KGR43X.SonderKalte);
                    tabelle[i].Preis -= Projekt.GetInstance().KGR43X.KalteAnlagen[2].TotalPreis;
                    tabelle[i].Preis -= Projekt.GetInstance().KGR43X.KalteAnlagen[3].TotalPreis;
                }
            }
        }
        return;
    }
}
