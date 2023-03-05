using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public class Collider : Component
{
    private Transform transform;
    private PhysicsBody physicsBody;

    private Vector2 bounds;
    private Vector2 offset;

    public Collider(Entity parentEntity) : base(parentEntity)
    {
        transform = parentEntity.GetComponent<Transform>();
        physicsBody = parentEntity.GetComponent<PhysicsBody>();

        bounds = Vector2.One;
        offset = Vector2.Zero;
    }

    public override void Update(GameTime gameTime)
    {}
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Globals.DebugMode){
            return;
        }

        ToolsExtended.DrawEmptyRect(
            spriteBatch,
            (int)transform.GetPosition().X + (int)offset.X,
            (int)transform.GetPosition().Y + (int)offset.Y,
            Globals.Tile_Size * (int)bounds.X,
            Globals.Tile_Size * (int)bounds.Y
        );
    }

    public void SetBounds(Vector2 bounds){
        this.bounds = bounds;

        //Centering Code

        // offset -= new Vector2(
        //     (Globals.Tile_Size * ((int)bounds.X - 1)) / 2,
        //     (Globals.Tile_Size * ((int)bounds.Y - 1)) / 2
        // );
    }
    public Vector2 GetBounds(){
        return bounds;
    }
    
    public void SetOffset(Vector2 offset){
        this.offset = offset;
    }
    public Vector2 GetOffset(){
        return offset;
    }
}