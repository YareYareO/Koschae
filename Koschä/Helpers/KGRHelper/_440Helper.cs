using System.Collections.ObjectModel;
using Koschä.Models.Elemente;

namespace Koschä.Helpers.KGRHelper;
public class _440Helper
{
    public static ObservableCollection<SystemTeil> UpdateTabelle2()
    {
        ObservableCollection<SystemTeil> tabelle = new ObservableCollection<SystemTeil>();
        string[] namen = { "MS-Anlage, Trafo", "NSHV", "Sicherheitslichtgeräte", "Notstromversorgung NEA", "USV" };
        int[] preise = { 80000, 125000, 50000, 200000, 1 }; 

        for(int i = 0; i < namen.Length; i++)
        {
            tabelle.Add(new SystemTeil(new Bereich(namen[i]), preise[i]));
        }
        return tabelle;
    }
}
