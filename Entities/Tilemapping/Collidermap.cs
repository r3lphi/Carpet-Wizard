using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Diagnostics;
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
        for (int x = 0; x < parentMap.GetData().GetLength(0); x++){
            int heightStreak = 0;
            int startingY = 0;

            for (int y = 0; y < parentMap.GetData().GetLength(1); y++){
                if (parentMap.GetData()[x, y] == null){
                    if (heightStreak == 0){
                        continue;
                    }

                    FormCollider(heightStreak, x, startingY);
                    heightStreak = 0;
                    continue;
                }

                heightStreak++;
                
                if (heightStreak == 1){
                    startingY = y;
                }
            }

            if (heightStreak > 0){
                FormCollider(heightStreak, x, startingY);
            }
        }

        MeshColliders(0);
    }

    public void FormCollider(int height, int x, int y){
        Object collider = new Object();

        collider.AddComponent(new Collider(collider));
        collider.GetComponent<Transform>().SetPosition(new Vector2(
            x * Globals.Tile_Size,
            y * Globals.Tile_Size
        ));

        collider.GetComponent<Collider>().SetSize(new Vector2(1, height));

        colliders.Add(collider);
    }

    public void MeshColliders(){
        MeshColliders(0);
    }
    public void MeshColliders(int startingIndex){
        int index = startingIndex;

        Vector2 rootPos = colliders[index].GetComponent<Transform>().GetPosition();

        while(index + 1 < colliders.Count){
            if (colliders[index + 1].GetComponent<Transform>().GetPosition().Y != rootPos.Y){
                MeshColliders(index + 1);
                break;
            }

            colliders[index].GetComponent<Collider>().SetSize(new Vector2(
                colliders[index].GetComponent<Collider>().GetSize().X + 1,
                colliders[index].GetComponent<Collider>().GetSize().Y
            ));

            colliders.RemoveAt(index + 1);
        }
    }

    public void Draw(SpriteBatch spriteBatch){
        foreach(Object collider in colliders){
            collider.Draw(spriteBatch);
        }
    }

    public List<Object> GetColliders(){
        return colliders;
    }
}