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

    private readonly ColliderType colliderType;
    public readonly Transform transform;

    public DynamoCollider(ColliderType colliderType, Transform transform)
    {        
        offset = Vector2.Zero;

        this.colliderType = colliderType;
        this.transform = transform;
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
    public Transform GetTransform(){
        return transform;
    }
    public ColliderType GetColliderType(){
        return colliderType;
    }
}