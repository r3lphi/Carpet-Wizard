using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Carpet_Wizard;

public class Transform : Component
{
    private Vector2 position;
    private float rotation;
    private Vector2 scale;

    public Transform(Entity parentEntity) : base(parentEntity)
    {
        position = Vector2.Zero;
        rotation = 0;
        scale = Vector2.One;
    }
    public Transform(Entity parentEntity, Vector2 _position, float _rotation, Vector2 _scale) : base(parentEntity)
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

    public float GetRotation(){
        return rotation;
    }
    public void SetRotation(float _rotation){
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

    public override bool Equals(object obj)
    {
        if ((obj is Transform) == false){
            return false;
        }

        Transform other = (Transform)obj;

        bool positionEqual = (other.position.X == position.X) && (other.position.Y == position.Y);
        bool rotationEqual = other.rotation == rotation;
        bool scaleEqual = (other.scale.X == scale.X) && (other.scale.Y == scale.Y);

        return (positionEqual && rotationEqual && scaleEqual);
    }
}