using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Helpers;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;
using Koschä.Models.Kostengruppen;

namespace Koschä.Models;
internal class Projekt
{
    private static Projekt? alleKGRs;
    public static Projekt GetInstance()
    {
        alleKGRs ??= new Projekt();
        return alleKGRs;
    }
    public void SetInstance(Projekt geladenesProjekt)
    {
        alleKGRs = geladenesProjekt;
    }

    public IKostengruppe[] AlleKostengruppen
    {
        get; private set;
    }
    public Projekt()
    {
        KGR410 = new Kostengruppe410();
        KGR420 = new Kostengruppe420();
        KGR43X = new Kostengruppe43X();
        KGR450 = new Kostengruppe450();

        AlleKostengruppen = new IKostengruppe[4];
        AlleKostengruppen[0] = KGR410;
        AlleKostengruppen[1] = KGR420;
        AlleKostengruppen[2] = KGR43X;
        AlleKostengruppen[3] = KGR450;
    }

    public string Projektname = "Beispielname";
    public ObservableCollection<Bereich> AlleBereiche { get; private set; } = StandardBereicheHelper.GetInstance().Bereiche();
    
    public Kostengruppe410 KGR410
    {
        get; private set;
    }
    public Kostengruppe420 KGR420
    {
        get; private set;
    }
    public Kostengruppe43X KGR43X
    {
        get; private set;
    }
    public Kostengruppe450 KGR450
    {
        get; private set;
    }

    
}
