using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Carpet_Wizard;

public class Tilemap
{
    private Tile[,] data = new Tile[(int)Globals.Canvas_Size.X, (int)Globals.Canvas_Size.Y];
    private Collidermap collidermap;

    private int world;
    private int level;
    private int screen_x;
    private int screen_y;

    public Tilemap(int world, int level, int screen_x, int screen_y){
        this.world = world;
        this.level = level;
        this.screen_x = screen_x;
        this.screen_y = screen_y;

        InitializeMap();
    }

    private void InitializeMap()
    {
        int[,] bitmap = GenerateBitmap();
        BitmapToTilemap(bitmap);
    }

    private int[,] GenerateBitmap()
    {
        string filename = "Screen_" + world + "_" + level + "_" + screen_x + "_" + screen_y + ".txt";
        string[] bitdata = FileManager.ReadLinesFromFile(FileManager.screensFolder, filename);

        int[,] bitmap = new int[(int)Globals.Canvas_Size.X, (int)Globals.Canvas_Size.Y];

        int x = 0;
        int y = 0;

        foreach (String line in bitdata){
            foreach (char character in line){
                if (!Char.IsDigit(character)){
                    if (character.ToString().Equals("n")){
                        bitmap[x, y] = -1;
                        x++;
                    }

                    continue;
                }

                int id = Convert.ToInt32(character.ToString());

                bitmap[x, y] = id;
                x++;
            }

            x = 0;
            y++;
        }

        return bitmap;
    }
    private void BitmapToTilemap(int[,] bitmap)
    {
        Print2DArray(bitmap);
    }

    public Tile[,] GetData(){
        return data;
    }
    public Collidermap GetColliderMap(){
        return collidermap;
    }

    public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}