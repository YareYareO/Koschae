
namespace Koschä.Models.Elemente;
public partial class ProzentSystem: SystemTeil
{
    
    public new int TotalPreis => (int) (Anzahl * Preis)/100;

    public ProzentSystem(string n, int a, int p) : base(n, a, p) { }
}
