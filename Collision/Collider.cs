using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Carpet_Wizard;

public enum ShapeType{
    Box = 0,
    Circle = 1,
    Polygon = 2
}

public abstract class Collider{
    public readonly ShapeType shapeType;
    public readonly Vector2 offset;

    public readonly Transform transform;

    public Collider(ShapeType shapeType, Vector2 offset, Transform transform){
        this.shapeType = shapeType;
        this.offset = offset;

        this.transform = transform;
    }

    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(SpriteBatch spriteBatch){}
}