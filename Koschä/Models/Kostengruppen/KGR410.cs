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

    public ObservableCollection<SystemTeil> Tabelle1;

    public ObservableCollection<SystemTeil> Tabelle2;

    public Kostengruppe410() 
    {
        Tabelle1 = new ObservableCollection<SystemTeil>();
        Tabelle2 = new ObservableCollection<SystemTeil>();
    }

    public void Setup()
    {
        Tabelle1 = KGRUpdate<SystemTeil>.SystemTabelleUmBereiche(Tabelle1, "410");
        Tabelle1 = _410Helper.UpdateTabelle1(Tabelle1); //gleichzeitig auch setup
        Tabelle2 = _410Helper.SetupTabelle2(Tabelle2);
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle1);
        gesamtkosten += SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2);
        return gesamtkosten;
    }

    

    public void FügNeuesSystemHinzu()
    {
        Tabelle1.Add(new SystemTeil());
    }
    public string UpdatedText()
    {
        return (SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle1) +
                            SystemGet<SystemTeil>.SummeGesamtKosten(Tabelle2)).ToString();
    }
}
