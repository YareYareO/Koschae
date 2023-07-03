using System.Collections.ObjectModel;
using System.Diagnostics;
using Koschä.Models;
using Koschä.Models.Elemente;

namespace Koschä.Helpers;
internal class KGRUpdate<T> where T : SystemTeil, new()
{
    public static ObservableCollection<T> SystemTabelleUmBereiche(ObservableCollection<T> tabelle, string kgrname)
    {
        Dictionary<string, int> dict = getRichtigeDictionary(kgrname);
        foreach (var bereich in Projekt.GetInstance().AlleBereiche) 
        {
            if (!tabelle.Any(system => (system.Name == bereich.Name)) & bereich.Anzahl != 0) //gibt es neue Bereiche? Dann füg ein neues System hinzu
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
            else if (true) //sind die Werte der Bereiche geändert? update die Fläche jeder Zeile und falls Anzahl gleich null ist, lösche die zeile
            {
                T leerezeile = new T();

                tabelle.Any(system =>
                {
                    if (system.Name == bereich.Name)
                    {
                        system.Anzahl = bereich.Anzahl;
                        if (bereich.Anzahl == 0) leerezeile = system;
                        return true;
                    }
                    return false;
                });
                tabelle.Remove(leerezeile);
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

    public static ObservableCollection<T> SystemTabelleUmAlleBereiche(ObservableCollection<T> tabelle)
    {
        foreach (var bereich in Projekt.GetInstance().AlleBereiche)
        {
            object[] constructorParams = new object[2];
            Bereich leererBereich = new Bereich(bereich.Name);
            constructorParams[0] = leererBereich;

            if (Activator.CreateInstance(typeof(T), constructorParams) is T instance)
            {
                tabelle.Add(instance);
            }
            else
            {
                Debug.WriteLine("Instanz ist null");
            }
        }
        return tabelle;
    }
}
