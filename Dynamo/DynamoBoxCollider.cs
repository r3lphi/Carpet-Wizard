using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

namespace Dynamo;

public class DynamoBoxCollider : DynamoCollider{
    private Vector2 size;

    public DynamoBoxCollider(Entity parentEntity) : base(parentEntity, ColliderType.Box){
        if (parentEntity.ContainsComponent<SpriteRenderer>()){
            size = new Vector2(
                parentEntity.GetComponent<SpriteRenderer>().GetSprite().Width,
                parentEntity.GetComponent<SpriteRenderer>().GetSprite().Height
            );
        }
        else{
            size = new Vector2(Globals.Tile_Size, Globals.Tile_Size);
        }        
    }
    public DynamoBoxCollider(Entity parentEntity, Vector2 size) : base(parentEntity, ColliderType.Box){
        this.size = size;     
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Globals.DebugMode){
            return;
        }

        ToolsExtended.DrawEmptyRect(
            spriteBatch,
            (int)transform.GetPosition().X + (int)GetOffset().X,
            (int)transform.GetPosition().Y + (int)GetOffset().Y,
            (int)size.X,
            (int)size.Y
        );

        base.Draw(spriteBatch);
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

    public int GetBottomBound(){
        return (int)((transform.GetPosition().Y + GetOffset().Y) + (size.Y * transform.GetScale().Y));
    }
    public int GetUpperBound(){
        return (int)(transform.GetPosition().Y + GetOffset().Y);
    }
    public int GetLeftBound(){
        return (int)(transform.GetPosition().X + GetOffset().X);
    }
    public int GetRightBound(){
        return (int)((transform.GetPosition().X + GetOffset().X) + (size.X * transform.GetScale().X));
    }
}