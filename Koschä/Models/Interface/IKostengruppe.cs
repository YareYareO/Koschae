using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Elemente;
using Koschä.Models.Interface;

namespace Koschä.Models;
public interface IKostengruppe
{
    public abstract int GetAlleTabellenkosten();
}
