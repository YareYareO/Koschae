using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Koschä.Models;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;

namespace Koschä.Helpers;
internal class KGRUpdate
{
    public static ObservableCollection<ISystem> SystemTabelleUmBereiche(ObservableCollection<ISystem> tabelle, string kgrname)
    {
        Dictionary<string, int> dict = getRichtigeDictionary(kgrname);
        foreach (var bereich in Projekt.GetInstance().AlleBereiche)
            {
                if (!tabelle.Any(system => (system.Name == bereich.Name)) & bereich.Anzahl != 0)
                {
                    tabelle.Add(new SystemTeil(bereich, dict[bereich.Name]));
                }
            }
        return tabelle;
    }

    private static Dictionary<string, int> getRichtigeDictionary(string kgrname)
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        switch (kgrname)
        {
            case "410":
                dictionary = StandardPreise.GetInstance().KGR410;
                break;
            case "431":
                dictionary = StandardPreise.GetInstance().KGR431;
                break;
            case "432":
                dictionary = StandardPreise.GetInstance().KGR432;
                break;
            case "450":
                dictionary = StandardPreise.GetInstance().KGR450;
                break;
        }

        return dictionary;
    }

    public static ObservableCollection<IAdaptivSystem> AdaptivsystemTabelleUmBereiche(ObservableCollection<IAdaptivSystem> tabelle, string kgrname)
    {
        Dictionary<string, int[]> dict = getRichtigeDictionaryAdaptiv(kgrname);
        foreach (var bereich in Projekt.GetInstance().AlleBereiche)
        {
            if (!tabelle.Any(system => (system.Name == bereich.Name)) & bereich.Anzahl != 0)
            {
                int[] werte = dict[bereich.Name];

                tabelle.Add(new AdaptivSystem(bereich, werte[0], werte[1]));
            }
        }
        return tabelle;
    }

    private static Dictionary<string, int[]> getRichtigeDictionaryAdaptiv(string kgrname)
    {
        Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
        switch (kgrname)
        {
            case "420":
                dictionary = StandardPreise.GetInstance().KGR420;
                break;
        }

        return dictionary;
    }


}
