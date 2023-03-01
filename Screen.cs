using System.Collections.Generic;

using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Screen
{
    private List<Entity> entities = new List<Entity>();
    private Tile[,] tilemap = new Tile[(int)Globals.Canvas_Size.X, (int)Globals.Canvas_Size.Y];

    public Screen(List<Entity> startingEntites){
        entities = startingEntites;
        tilemap = FileManager.ImportTilemap(0, 0, 0, 0);

        for (int x = 0; x < (int)Globals.Canvas_Size.X; x++){
            for (int y = 0; y < (int)Globals.Canvas_Size.Y; y++){
                if (tilemap[x, y] == null){
                    continue;
                }

                tilemap[x, y].GetComponent<Transform>().SetPosition(new Vector2(
                    x * Globals.Canvas_Size.X,
                    y * Globals.Canvas_Size.Y
                ));
            }
        }
    }

    public void Update(GameTime gameTime){
        foreach (Entity e in entities){
            e.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch){
        for (int x = 0; x < (int)Globals.Canvas_Size.X; x++){
            for (int y = 0; y < (int)Globals.Canvas_Size.Y; y++){
                if (tilemap[x, y] == null){
                    continue;
                }

                tilemap[x, y].Draw(spriteBatch);
            }
        }

        foreach (Entity e in entities){
            e.Draw(spriteBatch);
        }
    }
    public void DrawDebug(SpriteBatch spriteBatch){
        
    }
}