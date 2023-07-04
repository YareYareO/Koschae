using System.Collections.ObjectModel;
using Koschä.Models;
using Koschä.Models.Elemente;

namespace Koschä.Helpers.KGRHelper;
internal class _420Helper
{
    public static ObservableCollection<SystemTeil> SetupTabelle3()
    {
        ObservableCollection<SystemTeil> tabelle = new ObservableCollection<SystemTeil>();

        SystemTeil s1 = new SystemTeil("Statische HZG / dynamische HZG", 
            a: AdaptivSysGet<AdaptivSystem>.SummeKW(Projekt.GetInstance().KGR420.Statisches),
            p: 300);
        SystemTeil s2 = new SystemTeil("Thermoaktive Elemente",
            a: AdaptivSysGet<AdaptivSystem>.SummeKW(Projekt.GetInstance().KGR420.Thermoaktives),
            p: 650);
        SystemTeil s3 = new SystemTeil("Dynamische Wärme",
            a: _43XHelper.GetSummeDynHeizung(),
            p: 185);

        tabelle.Add(s1);
        tabelle.Add(s2);
        tabelle.Add(s3);

        return tabelle;
    }


    public static ObservableCollection<SystemTeil> SetupTabelle4()
    {
        ObservableCollection<SystemTeil> tabelle4 = new ObservableCollection<SystemTeil>();

        SystemTeil zeile = new SystemTeil("Fernwärmestation",
            a: SystemGet<SystemTeil>.SummeAnzahl(Projekt.GetInstance().KGR420.Warmebereitstellung),
            p:80);

        tabelle4.Add(zeile);

        return tabelle4;
    }
}
