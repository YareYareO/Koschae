using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Koschä.Models.Elemente;
public partial class ProzentSystem: SystemTeil
{
    
    public new int TotalPreis => (int) (Anzahl * Preis)/100;

    public ProzentSystem(string n, int a, int p) : base(n, a, p) { }
}
