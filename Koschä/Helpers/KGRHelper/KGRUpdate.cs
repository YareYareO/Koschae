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
internal class KGRUpdate<T> where T : SystemTeil, new()
{
    public static ObservableCollection<T> SystemTabelleUmBereiche(ObservableCollection<T> tabelle, string kgrname)
    {
        Dictionary<string, int> dict = getRichtigeDictionary(kgrname);
        foreach (var bereich in Projekt.GetInstance().AlleBereiche) 
        {
            if (!tabelle.Any(system => (system.Name == bereich.Name)) & bereich.Anzahl != 0)
            {
                object[] constructorParams = { bereich, dict[bereich.Name] };
                if (Activator.CreateInstance(typeof(T), constructorParams) is T instance)
                {
                    tabelle.Add(instance);
                }
                else
                {
                    Debug.WriteLine("Instanz ist null");
                }
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
            case "420":
                dictionary = StandardPreise.GetInstance().KGR420;
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
}
