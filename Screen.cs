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
    private Tilemap tilemap;

    public Screen(List<Entity> startingEntites){
        entities = startingEntites;
        tilemap = new Tilemap(0, 0, 0, 0);
    }

    public void Update(GameTime gameTime){
        foreach (Entity e in entities){
            e.Update(gameTime);
        }

        CollisionDetection();
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
            tilemap.GetColliderMap().Draw(spriteBatch);
        }

        foreach (Entity e in entities){
            e.Draw(spriteBatch);
        }
    }

    private void CollisionDetection(){
        quadtree.clear();

        foreach (Entity e in entities){
            quadtree.insert(e);
        }
        foreach(Object collider in tilemap.GetColliderMap().GetColliders()){
            quadtree.insert(collider);
        }

        List<Entity> intersectables = new List<Entity>();

        for (int i = 0; i < entities.Count; i++){
            intersectables.Clear();
            quadtree.getIntersectables(intersectables, entities[i]);

            foreach(Entity o in intersectables){
                if (o == entities[i]){
                    continue;
                }

                if (ToolsExtended.isTouching(
                    ToolsExtended.EntityToRect(entities[i]),
                    ToolsExtended.EntityToRect(o)
                ))
                {
                    if (!entities[i].ContainsComponent<PhysicsBody>()){
                        continue;
                    }

                    Transform creatureTransform = entities[i].GetComponent<Transform>();
                    Collider creatureCollider = entities[i].GetComponent<Collider>();

                    Transform objectTransform = o.GetComponent<Transform>();
                    Collider objectCollider = o.GetComponent<Collider>();
                    
                    //Checking if touching entity from bottom
                    if (creatureCollider.GetBottomBound() <= objectCollider.GetUpperBound()){
                        entities[i].GetComponent<PhysicsBody>().AddForce(new Vector2(
                            0,
                            -entities[i].GetComponent<PhysicsBody>().GetVelocity().Y
                        ));
                        creatureTransform.SetPosition(new Vector2(
                            creatureTransform.GetPosition().X,
                            objectCollider.GetUpperBound() - ((creatureTransform.GetScale().Y * creatureCollider.GetSize().Y) + creatureCollider.GetOffset().Y)
                        ));

                        continue;
                    }

                    // if (creatureCollider.GetLeftBound() <= objectCollider.GetRightBound()){
                    //     entities[i].GetComponent<PhysicsBody>().AddForce(new Vector2(
                    //         -entities[i].GetComponent<PhysicsBody>().GetVelocity().X,
                    //         0
                    //     ));
                    //     creatureTransform.SetPosition(new Vector2(
                    //         objectCollider.GetRightBound() + ((creatureTransform.GetScale().X * creatureCollider.GetSize().X) + creatureCollider.GetOffset().X),
                    //         creatureTransform.GetPosition().Y
                    //     ));

                    //     continue;
                    // }
                }
            }
        }
    }

    public List<Entity> GetEntities(){
        return entities;
    }
}