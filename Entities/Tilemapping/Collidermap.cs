using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Carpet_Wizard;

public class Collidermap
{
    private Tilemap parentMap;
    private List<Object> colliders;

    public Collidermap(Tilemap parentMap){
        this.parentMap = parentMap;

        colliders = new List<Object>();

        Initialize();
    }

    private void Initialize(){
        for (int y = 0; y < (int)Globals.Canvas_Size.Y; y++){
            int streak = 0;

            for (int x = 0; x < (int)Globals.Canvas_Size.X; x++){
                if (parentMap.GetData()[x, y] == null){
                    streak = 0;
                    continue;
                }

                streak++;
            }

            Console.WriteLine("Final streak was " + streak);
        }

        Console.WriteLine("Number of collider meshes formed is " + colliders.Count);
    }

    public void Draw(SpriteBatch spriteBatch){
        foreach(Object collider in colliders){
            collider.Draw(spriteBatch);
        }
    }
}