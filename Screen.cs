using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Screen
{
    private List<Entity> entities = new List<Entity>();
    private Quadtree quadtree = new Quadtree(0, new Rectangle(0, 0, Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight));
    // private Tilemap tilemap;

    public Screen(List<Entity> startingEntites){
        entities = startingEntites;
        // tilemap = new Tilemap(0, 0, 0, 0);
    }

    public void Update(GameTime gameTime){
        foreach (Entity e in entities){
            e.Update(gameTime);
        }

        // for (int x = 0; x < (int)Globals.Canvas_Size.X; x++){
        //     for (int y = 0; y < (int)Globals.Canvas_Size.Y; y++){
        //         if (tilemap.GetData()[x, y] == null){
        //             continue;
        //         }

        //         tilemap.GetData()[x, y].Update(gameTime);
        //     }
        // }

        // tilemap.GetCollisionmap().Update(gameTime);

        CollisionDetection();
    }
    public void Draw(SpriteBatch spriteBatch){
        // for (int x = 0; x < (int)Globals.Canvas_Size.X; x++){
        //     for (int y = 0; y < (int)Globals.Canvas_Size.Y; y++){
        //         if (tilemap.GetData()[x, y] == null){
        //             continue;
        //         }

        //         tilemap.GetData()[x, y].Draw(spriteBatch);
        //     }
        // }

        // if (Globals.DebugMode){
        //     tilemap.GetCollisionmap().Draw(spriteBatch);
        // }

        foreach (Entity e in entities){
            e.Draw(spriteBatch);
        }
    }

    private void CollisionDetection(){
        quadtree.clear();

        foreach (Entity e in entities){
            quadtree.insert(e);
        }
        // foreach(Object collider in tilemap.GetCollisionmap().GetColliders()){
        //     quadtree.insert(collider);
        // }

        List<Entity> intersectables = new List<Entity>();

        for (int i = 0; i < entities.Count; i++){
            intersectables.Clear();
            quadtree.getIntersectables(intersectables, entities[i]);

            PhysicsBody bodyA = entities[i].GetComponent<PhysicsBody>();

            foreach(Entity o in intersectables){
                if (o == entities[i] || !o.ContainsComponent<PhysicsBody>()){
                    continue;
                }

                PhysicsBody bodyB = o.GetComponent<PhysicsBody>();

                if (Collisions.PolygonsIntersect(
                    bodyA.GetColliderAs<BoxCollider>().GetTransformedVertices(), 
                    bodyB.GetColliderAs<BoxCollider>().GetTransformedVertices())){
                        bodyA.GetColliderAs<BoxCollider>().SetOutlineColor(Color.Blue);
                        bodyB.GetColliderAs<BoxCollider>().SetOutlineColor(Color.Blue);
                }
                else{
                    bodyA.GetColliderAs<BoxCollider>().SetOutlineColor(Color.Red);
                    bodyB.GetColliderAs<BoxCollider>().SetOutlineColor(Color.Red);
                }
            }
        }
    }

    public List<Entity> GetEntities(){
        return entities;
    }
}