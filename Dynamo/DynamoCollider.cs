using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

namespace Dynamo;

public enum ColliderType{
    Circle = 0,
    Box = 1,
    Polygon = 2
}

public abstract class DynamoCollider : Component
{
    protected Transform transform;
    private PhysicsBody physicsBody;

    // private Vector2 size;
    private Vector2 offset;

    private readonly ColliderType colliderType;

    public DynamoCollider(Entity parentEntity, ColliderType colliderType) : base(parentEntity)
    {
        transform = parentEntity.GetComponent<Transform>();
        physicsBody = parentEntity.GetComponent<PhysicsBody>();

        Debug.WriteLine(parentEntity.ContainsComponent<SpriteRenderer>());
        
        offset = Vector2.Zero;

        this.colliderType = colliderType;
    }

    public override void Update(GameTime gameTime)
    {}
    public override void Draw(SpriteBatch spriteBatch)
    {}
    
    public void SetOffset(Vector2 offset){
        this.offset = offset;
    }
    public Vector2 GetOffset(){
        return offset;
    }
    public ColliderType GetColliderType(){
        return colliderType;
    }
}