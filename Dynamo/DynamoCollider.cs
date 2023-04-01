using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

using Carpet_Wizard;

namespace Dynamo;

public enum ColliderType{
    Circle = 0,
    Box = 1,
    Polygon = 2
}

public abstract class DynamoCollider
{
    private Vector2 offset;

    public readonly ColliderType colliderType;
    public readonly Transform transform;
    public readonly PhysicsBody parentBody;

    public DynamoCollider(PhysicsBody parentBody, ColliderType colliderType, Transform transform)
    {        
        offset = Vector2.Zero;

        this.colliderType = colliderType;
        this.transform = transform;
        this.parentBody = parentBody;
    }

    public virtual void Initialize(){}
    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(SpriteBatch spriteBatch){}
    
    public void SetOffset(Vector2 offset){
        this.offset = offset;
    }
    public Vector2 GetOffset(){
        return offset;
    }
}