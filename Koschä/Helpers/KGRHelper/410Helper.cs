using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using Windows.Networking.PushNotifications;

namespace Koschä.Helpers.KGRHelper;
internal class _410Helper
{
    public static ObservableCollection<SystemTeil> UpdateTabelle1(ObservableCollection<SystemTeil> tabelle)
    {

        string[] namen = { "Dachflächen", "Terassen"};

        if (!tabelle.Any(system => system.Name == namen[0] | system.Name == namen[1]))
        {
            foreach (var name in namen)
            {
                tabelle.Add(new SystemTeil(new Bereich(name), StandardPreise.GetInstance().KGR410[name]));
            }
        }

        return tabelle;
    }

    public static ObservableCollection<SystemTeil> SetupTabelle2(ObservableCollection<SystemTeil> tabelle)
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
        return tabelle;
    }
}
