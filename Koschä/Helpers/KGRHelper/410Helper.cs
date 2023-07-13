using System.Collections.ObjectModel;
using Koschä.Models.Elemente;

namespace Koschä.Helpers.KGRHelper;
internal class _410Helper
{
    public static void SetupTabelle2(ref ObservableCollection<SystemTeil> tabelle)
    {

        if (!tabelle.Any(system => system.Name == "Druckerhöhungsanlagen"))
            {
            string[] namen = { "Behälter + Pumpenanlage", "Außenzapfstellen", "Druckerhöhungsanlagen", "Wasseraufbereitung (EH)", "Wasseraufbereitung (VE)", "KHS-Hygiensystem TWK + TWW",
                            "Fettabscheider", "F-SW-Leitungen mit Begleitheizung", "Hebeanlagen & SW-Pumpen", "Begleitheizung Dachabläufe / Rinnen",
                            "Grundleitungen", "Gasanlagen"};
            int[] preise = { 15000, 600, 15000, 7500, 25000, 64000, 25000, 50000, 15000, 25000, 300, 1 };

            for (int i = 0; i < namen.Length; i++)
            {
                tabelle.Add(new SystemTeil(namen[i], preise[i]));
            }
        }
        return;
    }
}
