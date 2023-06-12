using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Koschä.Helpers;
internal class StandardPreise
{
    private static StandardPreise? instance;

    public StandardPreise()
    {
    }

    public static StandardPreise GetInstance()
    {
        instance ??= new StandardPreise();

        return instance;
    }

    public void SetInstance(StandardPreise preise)
    {
        instance = preise;
    }

    [JsonInclude]
    public Dictionary<string, int> KGR410 = new()
    {
        { "Büroflächen", 10},
        { "Gastronomie", 25},
        { "Küche", 50},
        { "WC", 350},
        { "PuMi", 250},
        { "EDV", 35},
        { "Flur und Nebenräume", 5},
        { "Aufzüge", 5},
        { "Lager / zugehörige Nebenräume", 5},
        { "Technik", 5},
        { "Garage", 5},
        { "Rampe", 20},
        { "Müllraum", 5},
        { "Foyer", 10},
        { "Teeküchen", 100},
        { "Dachflächen", 70},
        { "Terassen", 40}
    };

    [JsonInclude]
    public Dictionary<string, int> KGR431 = new()
    {
        { "Büroflächen", 3},
        { "Gastronomie", 3},
        { "Küche", 3},
        { "WC", 3},
        { "PuMi", 3},
        { "EDV", 3},
        { "Flur und Nebenräume", 3},
        { "Aufzüge", 3},
        { "Lager / zugehörige Nebenräume", 3},
        { "Technik", 3},
        { "Garage", 3},
        { "Rampe", 3},
        { "Müllraum", 3},
        { "Foyer", 3},
        { "Teeküchen", 3},
        { "Dachflächen", 3},
        { "Terassen", 3}
    };

    [JsonInclude]
    public Dictionary<string, int> KGR432 = new()
    {
        { "Büroflächen", 70},
        { "Gastronomie", 70},
        { "Küche", 20},
        { "WC", 70},
        { "PuMi", 1},
        { "EDV", 1},
        { "Flur und Nebenräume", 1},
        { "Aufzüge", 20},
        { "Lager / zugehörige Nebenräume", 70},
        { "Technik", 70},
        { "Garage", 1},
        { "Rampe", 1},
        { "Müllraum", 1},
        { "Foyer", 1},
        { "Teeküchen", 1},
        { "Dachflächen", 1},
        { "Terassen", 1}
    };

    [JsonInclude]
    public Dictionary<string, int> KGR450 = new()
    {
        { "Büroflächen", 50 },
        { "Gastronomie", 45 },
        { "Küche", 40 },
        { "WC", 40 },
        { "PuMi", 40 },
        { "EDV", 40 },
        { "Flur und Nebenräume", 20 },
        { "Aufzüge", 25 },
        { "Lager / zugehörige Nebenräume", 10 },
        { "Technik",  10 },
        { "Garage", 10 },
        { "Rampe", 1 },
        { "Müllraum", 35 },
        { "Foyer", 50 },
        { "Teeküchen", 50}
    };
    [JsonInclude]
    public Dictionary<string, int > KGR420 = new()
    {
        { "Büroflächen", 35 },
        { "Gastronomie", 35 },
        { "Küche", 35 },
        { "WC", 35 },
        { "PuMi", 35 },
        { "EDV", 35 },
        { "Flur und Nebenräume", 35 },
        { "Aufzüge", 35 },
        { "Lager / zugehörige Nebenräume", 35 },
        { "Technik", 35 },
        { "Garage", 35 },
        { "Rampe", 35 },
        { "Müllraum", 35 },
        { "Foyer", 35 },
        { "Teeküchen", 35 }
    };
}