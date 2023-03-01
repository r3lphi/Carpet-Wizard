using System;
using System.IO;
using System.Diagnostics;

using Microsoft.Xna.Framework;

namespace Carpet_Wizard;

public static class FileManager
{
    static readonly string screensFolder = Directory.GetCurrentDirectory() + "\\ReqData\\Screens\\";

    public static Tile[,] ImportTilemap(int world, int level, int loc_x, int loc_y){
        String filename = "Screen_" + world + "_" + level + "_" + loc_x + "_" + loc_y + ".txt";

        if (File.Exists(screensFolder + filename)){
            Tile[,] map = new Tile[(int)Globals.Canvas_Size.X, (int)Globals.Canvas_Size.Y];

            string[] lines = File.ReadAllLines(screensFolder + filename);

            int x = 0;
            int y = 0;

            foreach (string line in lines){
                foreach(char character in line.ToCharArray()){
                    if (!Char.IsDigit(character)){
                        continue;
                    }

                    int calcd = (Convert.ToInt32(character) - 48);

                    if (Globals.Canvas_Size.X <= calcd){
                        continue;
                    }

                    map[x, y] = new Tile(Globals.s_Level[calcd]);
                    x += 1;
                }

                y += 1;
            }

            return map;
        }

        return null;
    }
}