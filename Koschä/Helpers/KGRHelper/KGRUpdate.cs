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
                object[] constructorParams = new object[2];
                try
                {
                    constructorParams[0] = bereich;
                    constructorParams[1] = dict[bereich.Name];
                }
                catch (KeyNotFoundException)
                {
                    constructorParams[0] = bereich;
                    constructorParams[1] = 0;
                }
                
                if (Activator.CreateInstance(typeof(T), constructorParams) is T instance)
                {
                    tabelle.Add(instance);
                }
                else
                {
                    Debug.WriteLine("Instanz ist null");
                }
            }
            else if (tabelle.Any(system => (system.Name == bereich.Name))) //updated die Fläche jeder Zeile
            {
                List<T> leerezeilen = new List<T>();

                foreach (T zeile in tabelle)
                {
                    if (zeile.Name == bereich.Name)
                    {
                        zeile.Anzahl = bereich.Anzahl;

                        if (bereich.Anzahl == 0) leerezeilen.Add(zeile);
                    }
                }
                foreach (var leerzeile in leerezeilen)
                {
                    tabelle.Remove(leerzeile);
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
            case "440":
                dictionary = StandardPreise.GetInstance().KGR440;
                break;
            case "450":
                dictionary = StandardPreise.GetInstance().KGR450;
                break;
            case "470":
                dictionary = StandardPreise.GetInstance().KGR470;
                break;
        }
        return dictionary;
    }

}
