﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Koschä.Helpers.KGRHelper;
using Koschä.Models.Elemente;

namespace Koschä.Models.Kostengruppen;
public class Kostengruppe460: IKostengruppe
{
    [JsonInclude]
    public ObservableCollection<DoppelSystem> Tabelle;

    public Kostengruppe460()
    {
        Tabelle = new ObservableCollection<DoppelSystem>();
    }

    public void Setup()
    {
    }

    public int GetAlleTabellenkosten()
    {
        int gesamtkosten = 0;
        gesamtkosten += SystemGet<DoppelSystem>.SummeGesamtKostenDoppelSystem(Tabelle);
        return gesamtkosten;
    }

    public void AddAufzug()
    {
        Tabelle.Add(new DoppelSystem());
    }
}
