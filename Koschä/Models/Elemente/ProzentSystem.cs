
namespace Koschä.Models.Elemente;
public partial class ProzentSystem: SystemTeil
{
    
    public new int TotalPreis => (int) Math.Ceiling(((double) Anzahl * (double) Preis)/100.0);

    public ProzentSystem(string n, int a, int p) : base(n, a, p) { }
}
