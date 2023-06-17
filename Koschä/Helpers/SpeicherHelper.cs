using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Koschä.Models;
using System.Diagnostics;
using Windows.Storage.Pickers;
using System.Runtime.InteropServices;
using WinRT;
using Windows.ApplicationModel.VoiceCommands;
using Koschä.Views;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.Store;

namespace Koschä.Helpers;

class SpeicherHelper
{

    private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Koschä/";
    private static readonly string projectpath = path + "/Projekte/";
    private static readonly string preispath = path + "/Preise/";
    public static void SpeicherDaten()
    {
        var projekt = Projekt.GetInstance();
        
        if (!Directory.Exists(projectpath))
        {
            _ = Directory.CreateDirectory(projectpath);
        }

        var filepath = projectpath + projekt.Projektname + ".json";
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(projekt, options);

        Debug.WriteLine(jsonString);
        File.WriteAllText(filepath, jsonString);
    }




    [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto, PreserveSig = true, SetLastError = false)]
    public static extern IntPtr GetActiveWindow();

    public static async Task LadeDaten()
    {
        var picker = new FileOpenPicker();
        picker.FileTypeFilter.Add("*");
        var initializeWithWindowWrapper = picker.As<IInitializeWithWindow>();
        initializeWithWindowWrapper.Initialize(GetActiveWindow());
        var file = await picker.PickSingleFileAsync();

        if (file != null)
        {
            var projektstring = File.ReadAllText(projectpath + file.Name);

            Projekt? projekt =
                JsonSerializer.Deserialize<Projekt>(projektstring);
            if (projekt != null)
            {
                Projekt.GetInstance().SetInstance(projekt);
            }
        }
        else
        {
            Debug.WriteLine("Operation cancelled.");
        }
    }

    

}
