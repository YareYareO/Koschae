using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koschä.Models.Elemente;

namespace Koschä.Helpers;
internal class StandardBereicheHelper
{
    private static StandardBereicheHelper? instance;

    private StandardBereicheHelper()
    {
    }
    public static StandardBereicheHelper GetInstance()
    {
        instance ??= new StandardBereicheHelper();

        return instance;
    }

    private readonly string[] bereichenamen = {"Büroflächen", "Gastronomie", "Küche", "WC", "PuMi", "EDV", "Flur und Nebenräume",
                                "Aufzüge", "Lager / zugehörige Nebenräume", "Technik", "Garage", "Rampe", "Müllraum",
                                "Foyer", "Teeküchen"};

    public ObservableCollection<Bereich> Bereiche()
    {
        ObservableCollection<Bereich> bereiche = new ObservableCollection<Bereich>();

        foreach (var name in bereichenamen)
        {
            bereiche.Add(new Bereich(name));
        }

        return bereiche;
    }
}
