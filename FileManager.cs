using System;
using System.IO;
using System.Diagnostics;

using Microsoft.Xna.Framework;

namespace Carpet_Wizard;

public static class FileManager
{
    public static readonly string screensFolder = Directory.GetCurrentDirectory() + "/ReqData/Screens/";

    public static String[] ReadLinesFromFile(string path, string filename){
        string toSearch = path + filename;

        if (!File.Exists(toSearch)){
            Console.WriteLine(toSearch);
            return null;
        }

        return File.ReadAllLines(toSearch);
    }
}