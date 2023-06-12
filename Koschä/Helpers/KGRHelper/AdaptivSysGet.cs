using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Interface;

namespace Koschä.Helpers.KGRHelper;
public class AdaptivSysGet<A> where A : IAdaptivSystem
{
    public static int SummeKW(ObservableCollection<A> tabelle)
    {
        int kW = 0;

        foreach (var zeile in tabelle)
        {
            kW += zeile.LeistungGesamt;
        }
        return kW;
    }
}
