using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Helpers.KGRHelper;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Koschä.Models.Kostengruppen;
public partial class Kostengruppe410 : IKostengruppe
{

    public ObservableCollection<ISystem> Tabelle1;

    public ObservableCollection<ISystem> Tabelle2;

    public Kostengruppe410() 
    {
        Tabelle1 = new ObservableCollection<ISystem>();
        Tabelle2 = new ObservableCollection<ISystem>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate.SystemTabelleUmBereiche(Tabelle1, "410");
        Tabelle1 = _410Helper.UpdateTabelle1(Tabelle1); //gleichzeitig auch setup
        Tabelle2 = _410Helper.SetupTabelle2(Tabelle2);
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += KGRGet.SummeGesamtKostenEinfach(Tabelle1);
        gesamtkosten += KGRGet.SummeGesamtKostenEinfach(Tabelle2);
        return gesamtkosten;
    }

    

    public void FügNeuesSystemHinzu()
    {
        Tabelle1.Add(new SystemTeil());
    }
    public string UpdatedText()
    {
        return (KGRGet.SummeGesamtKostenEinfach(Tabelle1) +
                            KGRGet.SummeGesamtKostenEinfach(Tabelle2)).ToString();
    }
}
