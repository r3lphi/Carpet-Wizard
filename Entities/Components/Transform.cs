using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Carpet_Wizard;

public class Transform : Component
{
    private Vector2 position;
    private int rotation;
    private Vector2 scale;

    public Transform(Entity parentEntity) : base(parentEntity)
    {
        position = Vector2.Zero;
        rotation = 0;
        scale = Vector2.One;
    }
    public Transform(Entity parentEntity, Vector2 _position, int _rotation, Vector2 _scale) : base(parentEntity)
    {
        position = _position;
        rotation = _rotation;
        scale = _scale;
    }

    public override void Update(GameTime gameTime)
    {}
    public override void Draw(SpriteBatch spriteBatch)
    {}

    public Vector2 GetPosition(){
        return position;
    }
    public void SetPosition(Vector2 _position){
        position = _position;
    }

    public int GetRotation(){
        return rotation;
    }
    public void SetRotation(int _rotation){
        rotation = _rotation;
    }

    public Vector2 GetScale(){
        return scale;
    }
    public Vector2 GetScaleABS(){
        return new Vector2(Math.Abs(scale.X), Math.Abs(scale.Y));
    }
    public void SetScale(Vector2 _scale){
        scale = _scale;
    }
}