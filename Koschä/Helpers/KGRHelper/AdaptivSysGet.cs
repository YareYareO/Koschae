using System.Collections.ObjectModel;
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
