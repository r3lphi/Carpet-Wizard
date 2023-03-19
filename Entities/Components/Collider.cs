using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

namespace Carpet_Wizard;

public class Collider : Component
{
    private Transform transform;
    private PhysicsBody physicsBody;

    private Vector2 size;
    private Vector2 offset;

    public Collider(Entity parentEntity) : base(parentEntity)
    {
        transform = parentEntity.GetComponent<Transform>();
        physicsBody = parentEntity.GetComponent<PhysicsBody>();

        Debug.WriteLine(parentEntity.ContainsComponent<SpriteRenderer>());
        
        if (parentEntity.ContainsComponent<SpriteRenderer>()){
            size = new Vector2(
                parentEntity.GetComponent<SpriteRenderer>().GetSprite().Width,
                parentEntity.GetComponent<SpriteRenderer>().GetSprite().Height
            );
        }
        else{
            size = new Vector2(Globals.Tile_Size, Globals.Tile_Size);
        }
        
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
            (int)size.X,
            (int)size.Y
        );
    }

    public void SetSize(Vector2 size){
        this.size = size;

        //Centering Code

        // offset -= new Vector2(
        //     (Globals.Tile_Size * ((int)size.X - 1)) / 2,
        //     (Globals.Tile_Size * ((int)size.Y - 1)) / 2
        // );
    }
    public Vector2 GetSize(){
        return size;
    }
    
    public void SetOffset(Vector2 offset){
        this.offset = offset;
    }
    public Vector2 GetOffset(){
        return offset;
    }

    public int GetBottomBound(){
        return (int)((transform.GetPosition().Y + offset.Y) + (size.Y * transform.GetScale().Y));
    }
    public int GetUpperBound(){
        return (int)(transform.GetPosition().Y + offset.Y);
    }
    public int GetLeftBound(){
        return (int)(transform.GetPosition().X + offset.X);
    }
    public int GetRightBound(){
        return (int)((transform.GetPosition().X + offset.X) + (size.X * transform.GetScale().X));
    }

    // public bool isIntersecting(Collider other){
    //     Rectangle a = new Rectangle(
    //         (int)(transform.GetPosition().X + offset.X),
    //         (int)(transform.GetPosition().Y + offset.Y),
    //         (int)size.X,
    //         (int)size.Y
    //     );

    //     Transform otherTransform = other.GetParent().GetComponent<Transform>();

    //     Rectangle b = new Rectangle(
    //         (int)(otherTransform.GetPosition().X + offset.X),
    //         (int)(otherTransform.GetPosition().Y + offset.Y),
    //         (int)size.X,
    //         (int)size.Y
    //     );

    //     return (
    //         a.X <= b.X + b.Width &&
    //         a.X + a.Width >= b.X &&
    //         a.Y <= b.Y + b.Height &&
    //         a.Y + a.Height >= b.Y
    //     );
    // }
}