﻿using System.Collections.ObjectModel;
using Koschä.Models.Elemente;

namespace Koschä.Helpers.KGRHelper;
public class _470Helper
{
    public static void UpdateTabelle3(ref ObservableCollection<DoppelSystem> tabelle)
    {
        string[] namen = { "Wandhydranten", "Feuerlöscher", "Ansul Küche", "Sprinklerzentrale"};
        int[] preise = { 3400, 300, 35000, 250000};

        for (int i = 0; i < namen.Length; i++)
        {
            tabelle.Add(new DoppelSystem(namen[i], preise[i]));
        }
        return;
    }
}
