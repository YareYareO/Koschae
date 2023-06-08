using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Interface;

namespace Koschä.Models.Elemente;
public class Bereich : IElement
{
    public string Name
    {
        get; set;
    }
    public int Anzahl
    {
        get; set;
    }

    public Bereich()
    {
        Name = "???";
        Anzahl = 0;
    }

    public Bereich(string name)
    {
        Name = name;
        Anzahl = 0;
    }
}
