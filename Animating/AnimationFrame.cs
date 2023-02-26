using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class AnimationFrame
{
    private Texture2D sprite;
    private float length;

    public AnimationFrame(Texture2D _sprite, float _length){
        sprite = _sprite;
        length = _length;
    }

    public Texture2D GetSprite(){
        return sprite;
    }
    public float GetLength(){
        return length;
    }
}