using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;

namespace Koschä.Helpers.KGRHelper;
internal class _420Helper
{
    public static ObservableCollection<ISystem> SetupTabelle3()
    {
        ObservableCollection<ISystem> tabelle = new ObservableCollection<ISystem>();

        ISystem s1 = new SystemTeil("Statische HZG / dynamische HZG", 
            a: KGRGet.SummeKW(Projekt.GetInstance().KGR420.Tabelle1),
            p: 300);
        ISystem s2 = new SystemTeil("Thermoaktive Elemente",
            a: KGRGet.SummeKW(Projekt.GetInstance().KGR420.Tabelle2),
            p: 300);
        ISystem s3 = new SystemTeil("Dynamische Wärme",
            a: _43XHelper.GetSummeDynHeizung(),
            p: 185);

        tabelle.Add(s1);
        tabelle.Add(s2);
        tabelle.Add(s3);

        return tabelle;
    }

    public static ObservableCollection<ISystem> SetupTabelle4()
    {
        ObservableCollection<ISystem> tabelle4 = new ObservableCollection<ISystem>();

        SystemTeil zeile = new SystemTeil("Fernwärmestation",
            a: KGRGet.SummeAnzahl(Projekt.GetInstance().KGR420.Tabelle3),
            p:80);

        tabelle4.Add(zeile);

        return tabelle4;

    }
}
