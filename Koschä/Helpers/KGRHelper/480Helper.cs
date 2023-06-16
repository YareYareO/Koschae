using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models;
using Koschä.Models.Elemente;

namespace Koschä.Helpers.KGRHelper;
public class _480Helper
{
    public static ObservableCollection<ProzentSystem> SetupTabelle()
    {
        ObservableCollection<ProzentSystem> tabelle = new ObservableCollection<ProzentSystem>();

        string[] namen = { "Sanitärtechnik", "Heizungstechnik", "Lüftungs- u. Kältetechnik", "Starkstromtechnik", "Fernmeldetechnik",
                            "Förderanlagen", "Nutzungsspezifische Anlagen"};

        IKostengruppe[] kgrref = Projekt.GetInstance().AlleKostengruppen;
        
        int[] preise = new int[7];
        for (int i = 0; i < preise.Length; i++)
        {
            preise[i] = kgrref[i].GetAlleTabellenkosten();
        }

        int[] prozente = { 2, 5, 10, 2, 2, 2, 2};

        for(int i = 0;i < preise.Length;i++)
        {
            ProzentSystem system = new ProzentSystem(namen[i], a: prozente[i], p: preise[i]);
            tabelle.Add(system);
        }

        return tabelle;

    }

    public static ObservableCollection<ProzentSystem> UpdateTabelle(ObservableCollection<ProzentSystem> tabelle)
    {

        IKostengruppe[] kgrref = Projekt.GetInstance().AlleKostengruppen;

        for (int i = 0; i < kgrref.Length-1; i++)
        {
            tabelle[i].Preis = kgrref[i].GetAlleTabellenkosten();
        }
        return tabelle;
    }
}
