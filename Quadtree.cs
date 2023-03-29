using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

using Dynamo;

namespace Carpet_Wizard;

public class Quadtree
{
    //Settings
    private int MAX_OBJECTS = 10;
    private int MAX_SPLITS = 5;

    //Instance Attributes
    private int splits;
    private List<Entity> entities;
    private Rectangle bounds;
    private Quadtree[] nodes;

    public Quadtree(int splits, Rectangle bounds){
        this.splits = splits;
        this.bounds = bounds;

        entities = new List<Entity>();
        nodes = new Quadtree[4];
    }

    //Clears all entities from all nodes
    public void clear(){
        entities.Clear();

        for (int i = 0; i < nodes.Length; i++){
            if (nodes[i] == null){
                continue;
            }

            nodes[i].clear();
            nodes[i] = null;
        }
    }

    //Splits an existing node into four halves
    private void split(){
        int subWidth = (int)(bounds.Width / 2);
        int subHeight = (int)(bounds.Height / 2);

        nodes[0] = new Quadtree(splits + 1, new Rectangle(
            bounds.X + subWidth,
            bounds.Y,
            subWidth,
            subHeight
        ));
        nodes[1] = new Quadtree(splits + 1, new Rectangle(
            bounds.X,
            bounds.Y,
            subWidth,
            subHeight
        ));
        nodes[2] = new Quadtree(splits + 1, new Rectangle(
            bounds.X,
            bounds.Y + subHeight,
            subWidth,
            subHeight
        ));
        nodes[3] = new Quadtree(splits + 1, new Rectangle(
            bounds.X + subWidth,
            bounds.Y + subHeight,
            subWidth,
            subHeight
        ));

        splits++;
    }

    /*
    * Finds out which node an entity fits into. If it doesn't fit into any (return value of -1),
    * then it means the entity is part of the parent node
    */
    private int getFittedNode(Rectangle rect){        
        double verticalMidpoint = bounds.X + (bounds.Width / 2);
        double horizontalMidpoint = bounds.Y + (bounds.Height / 2);

        bool fitsInTop = (rect.Y < horizontalMidpoint && rect.Y + rect.Height < horizontalMidpoint);
        bool fitsInBottom = (rect.Y > horizontalMidpoint);
        bool fitsInLeft = (rect.X < verticalMidpoint && rect.X + rect.Width < verticalMidpoint);
        bool fitsInRight = (rect.X > verticalMidpoint);

        if (fitsInLeft){
            if (fitsInTop){
                return 1;
            }

            return 2;
        }

        if (fitsInRight){
            if (fitsInTop){
                return 0;
            }

            return 3;
        }

        return -1;
    }

    public void insert(Entity e){
        if (e.GetComponent<PhysicsBody>() == null){
            return;
        }

        Rectangle eRect = new Rectangle(
            new Point(
                (int)(e.GetComponent<Transform>().GetPosition().X + e.GetComponent<PhysicsBody>().GetColliderAs<DynamoBoxCollider>().GetOffset().X),
                (int)(e.GetComponent<Transform>().GetPosition().Y + e.GetComponent<PhysicsBody>().GetColliderAs<DynamoBoxCollider>().GetOffset().Y)
            ),
            new Point(
                (int)(Globals.Tile_Size * e.GetComponent<PhysicsBody>().GetColliderAs<DynamoBoxCollider>().GetSize().X),
                (int)(Globals.Tile_Size * e.GetComponent<PhysicsBody>().GetColliderAs<DynamoBoxCollider>().GetSize().Y)
            )
        );

        if (nodes[0] != null){
            int node = getFittedNode(eRect);

            if (node != -1){
                nodes[node].insert(e);

                return;
            }
        }

        entities.Add(e);

        if (entities.Count > MAX_OBJECTS && splits < MAX_SPLITS){
            if (nodes[0] == null){
                split();
            }

            int i = 0;

            while(i < entities.Count){
                int node = getFittedNode(ToolsExtended.EntityToRect(e));

                if (node != -1){
                    Entity r = entities[i];
                    entities.RemoveAt(i);
                    nodes[node].insert(r);

                    continue;
                }

                i++;
            }
        }
    }

    public List<Entity> getIntersectables(List<Entity> toReturn, Entity e){
        int node = getFittedNode(ToolsExtended.EntityToRect(e));

        if (node != -1 && nodes[0] != null){
            nodes[node].getIntersectables(toReturn, e);
        }

        foreach (Entity _e in entities){
            toReturn.Add(_e);
        }

        return toReturn;
    }

    public void Draw(SpriteBatch spriteBatch){
        for (int i = 0; i < splits; i++){
            int subWidth = (int)(bounds.Width / (2^i));
            int subHeight = (int)(bounds.Height / (2^i));

            int x = bounds.X / (2^(i - 1));
            int y = bounds.Y / (2^(i - 1));

            ToolsExtended.DrawEmptyRect(
                spriteBatch,
                x + subWidth,
                y,
                subWidth,
                subHeight
            );
            ToolsExtended.DrawEmptyRect(
                spriteBatch,
                x,
                y,
                subWidth,
                subHeight
            );
            ToolsExtended.DrawEmptyRect(
                spriteBatch,
                x,
                y + subHeight,
                subWidth,
                subHeight
            );
            ToolsExtended.DrawEmptyRect(
                spriteBatch,
                x + subWidth,
                y + subHeight,
                subWidth,
                subHeight
            );
        }
    }
}