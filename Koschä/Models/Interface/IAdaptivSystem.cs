using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koschä.Models.Interface;
public interface IAdaptivSystem: ISystem
{
    public int LeistungGesamt
    {
        get;
    }
}
