using Microsoft.Xna.Framework;

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

        collidermap = new Collidermap(this);
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
        for (int x = 0; x < bitmap.GetLength(0); x++){
            for (int y = 0; y < bitmap.GetLength(1); y++){
                int id = bitmap[x, y];

                if (id < 0 || id > Globals.s_Level.GetLength(0)){
                    continue;
                }

                Tile tile = new Tile(Globals.s_Level[id]);
                tile.GetComponent<Transform>().SetPosition(new Vector2(
                    x * Globals.Tile_Size,
                    y * Globals.Tile_Size
                ));

                data.SetValue(tile, x, y);
            }
        }
    }

    public Tile[,] GetData(){
        return data;
    }
    public Collidermap GetColliderMap(){
        return collidermap;
    }
}