using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        alleKGRs.SetAlleKostengruppen();
    }
    [JsonIgnore]
    public IKostengruppe[] AlleKostengruppen
    {
        get; private set;
    }
    public Projekt()
    {
        KGR410 = new Kostengruppe410();
        KGR420 = new Kostengruppe420();
        KGR43X = new Kostengruppe43X();
        KGR440 = new Kostengruppe440();
        KGR450 = new Kostengruppe450();
        KGR460 = new Kostengruppe460();
        KGR470 = new Kostengruppe470();
        KGR480490 = new Kostengruppe480490();
        AlleKostengruppen = new IKostengruppe[1]; // nur damit der compiler nicht nervt
        SetAlleKostengruppen();
    }

    private void SetAlleKostengruppen()
    {
        AlleKostengruppen = new IKostengruppe[8];
        AlleKostengruppen[0] = KGR410;
        AlleKostengruppen[1] = KGR420;
        AlleKostengruppen[2] = KGR43X;
        AlleKostengruppen[3] = KGR440;
        AlleKostengruppen[4] = KGR450;
        AlleKostengruppen[5] = KGR460;
        AlleKostengruppen[6] = KGR470;
        AlleKostengruppen[7] = KGR480490;
    }

    
    [JsonInclude]
    public string Projektname = "Beispielname";

    [JsonInclude]
    public ObservableCollection<Bereich> AlleBereiche { get; private set; } = StandardBereicheHelper.GetInstance().Bereiche();
    [JsonInclude]
    public Kostengruppe410 KGR410
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe420 KGR420
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe43X KGR43X
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe440 KGR440
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe450 KGR450
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe460 KGR460
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe470 KGR470
    {
        get; private set;
    }
    [JsonInclude]
    public Kostengruppe480490 KGR480490
    {
        get; private set;
    }

}
