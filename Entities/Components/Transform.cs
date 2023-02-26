using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Transform
{
    private Vector2 position;
    private int rotation;
    private Vector2 scale;

    public Transform(){
        position = Vector2.Zero;
        rotation = 0;
        scale = Vector2.One;
    }
    public Transform(Vector2 _position, int _rotation, Vector2 _scale){
        position = _position;
        rotation = _rotation;
        scale = _scale;
    }

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
    public void SetScale(Vector2 _scale){
        scale = _scale;
    }
}