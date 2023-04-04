using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Carpet_Wizard;

public class Collisionmap
{
    private Tilemap parentMap;
    private List<Object> colliders;

    public Collisionmap(Tilemap parentMap){
        this.parentMap = parentMap;

        colliders = new List<Object>();

        Initialize();
    }

    private void Initialize(){
        List<Rectangle> tileNums = new List<Rectangle>();

        for (int x = 0; x < parentMap.GetData().GetLength(0); x++){
            int heightStreak = 0;
            int startingY = 0;

            for (int y = 0; y < parentMap.GetData().GetLength(1); y++){
                if (parentMap.GetData()[x, y] == null){
                    if (heightStreak == 0){
                        continue;
                    }

                    tileNums.Add(new Rectangle(x, startingY, Globals.Tile_Size, heightStreak));
                    heightStreak = 0;
                    continue;
                }

                heightStreak++;
                
                if (heightStreak == 1){
                    startingY = y;
                }
            }

            if (heightStreak > 0){
                tileNums.Add(new Rectangle(x, startingY, parentMap.GetData()[x, startingY].GetComponent<SpriteRenderer>().GetSprite().Width, heightStreak));
            }
        }

        MeshColliders(tileNums);
    }

    // public void FormCollider(int height, int x, int y){
    //     Object collider = new Object();

    //     if (PhysicsBody.CreateBoxBody(collider, collider.GetComponent<Transform>(), new Vector2(Globals.Tile_Size, Globals.Tile_Size * height), Vector2.Zero, 10, 0, true, out PhysicsBody body, out string err)){
    //         collider.AddComponent(body);
    //     }
    //     else{
    //         throw new Exception(err);
    //     }

    //     collider.GetComponent<Transform>().SetPosition(new Vector2(
    //         x * Globals.Tile_Size,
    //         y * Globals.Tile_Size
    //     ));

    //     colliders.Add(collider);
    // }

    public void MeshColliders(List<Rectangle> tileNums){
        MeshColliders(tileNums, 0);
    }
    public void MeshColliders(List<Rectangle> tileNums, int startingIndex){
        int index = startingIndex;

        Vector2 rootPos = colliders[index].GetComponent<Transform>().GetPosition();

        while(index + 1 < colliders.Count){
            if (colliders[index + 1].GetComponent<Transform>().GetPosition().Y != rootPos.Y){
                if (PhysicsBody.CreateBoxBody(colliders[index], colliders[index].GetComponent<Transform>(), new Vector2(tileNums[index].X + tileNums[index + 1].X, tileNums[index].Y + tileNums[index + 1].Y), Vector2.Zero, 0, 0, true, out PhysicsBody body, out string err)){
                    colliders[index].AddComponent(body);
                }
                else{
                    throw new Exception(err);
                }

                MeshColliders(tileNums, index + 1);
                break;
            }

            tileNums[index] = new Rectangle(
                tileNums[index].X,
                tileNums[index].Y,
                tileNums[index].Width + (int)colliders[index + 1].GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().size.X,
                tileNums[index].Height
            );

            // colliders[index].GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().SetSize(new Vector2(
            //     colliders[index].GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().GetSize().X + colliders[index + 1].GetComponent<PhysicsBody>().GetColliderAs<DynamoBoxCollider>().GetSize().X,
            //     colliders[index].GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().GetSize().Y + colliders[index + 1].GetComponent<PhysicsBody>().GetColliderAs<DynamoBoxCollider>().GetSize().Y
            // ));

            tileNums.RemoveAt(index + 1);
        }
    }

    public void Update(GameTime gameTime){
        foreach(Object collider in colliders){
            collider.Update(gameTime);
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