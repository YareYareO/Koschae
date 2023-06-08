using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;
public class TabellenElement: IElement
{
    public string Name
    {
        get; set;
    }

    public int Anzahl
    {
        get; set;
    }

    public TabellenElement(string name, int anzahl)
    {
        Name = name;
        Anzahl = anzahl;
    }
}
