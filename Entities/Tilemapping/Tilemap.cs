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

        collidermap = new Collidermap(this);
    }

    private void InitializeMap(){
        string filename = "Screen_" + world + "_" + level + "_" + screen_x + "_" + screen_y + ".txt";
        string[] bitdata = FileManager.ReadLinesFromFile(FileManager.screensFolder, filename);

        int x = 0;
        int y = 0;

        int[,] bitmap = new int[(int)Globals.Canvas_Size.X, (int)Globals.Canvas_Size.Y];
        
        foreach (string line in bitdata){
            foreach (char character in line){
                if (!Char.IsDigit(character)){
                    bitmap[x, y] = -1;
                    continue;
                }

                int id = Int32.Parse(character.ToString());

                if (id >= Globals.s_Level.Length){
                    bitmap[x, y] = -1;
                    continue;
                }

                bitmap[x, y] = id;
            }
        }

        for (int _x = 0; _x < (int)Globals.Canvas_Size.X; _x++){
            for (int _y = 0; _y < (int)Globals.Canvas_Size.Y; _y++){
                data[_x, _y] = new Tile(Globals.s_Level[id]);
                data[_x, _y].GetComponent<Transform>().SetPosition(new Vector2(
                    _x * Globals.Tile_Size,
                    _y * Globals.Tile_Size
                ));

                _x++;
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