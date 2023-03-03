using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Screen
{
    private List<Entity> entities = new List<Entity>();
    private Tilemap tilemap;

    public Screen(List<Entity> startingEntites){
        entities = startingEntites;
        tilemap = new Tilemap(0, 0, 0, 0);
    }

    public void Update(GameTime gameTime){
        foreach (Entity e in entities){
            e.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch){
        for (int x = 0; x < (int)Globals.Canvas_Size.X; x++){
            for (int y = 0; y < (int)Globals.Canvas_Size.Y; y++){
                if (tilemap.GetData()[x, y] == null){
                    continue;
                }

                tilemap.GetData()[x, y].Draw(spriteBatch);
            }
        }

        if (Globals.DebugMode){
            //TODO
        }

        foreach (Entity e in entities){
            e.Draw(spriteBatch);
        }
    }
}