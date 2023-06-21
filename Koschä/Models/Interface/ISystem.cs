
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
