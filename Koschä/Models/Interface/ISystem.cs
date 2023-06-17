using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koschä.Models.Interface;
public interface ISystem: IElement
{
    public new string Name
    {
        get;
        set;
    }
    public int Anzahl
    {
        get;
        set;
    }
    public int Preis
    {
        get;
        set;
    }
    public int TotalPreis => Anzahl * Preis;
}
