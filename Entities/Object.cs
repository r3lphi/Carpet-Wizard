using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Object : Creature
{
    public Object(){
        transform = new Transform();

        Initialize();
    }
    public Object(Texture2D _sprite){
        sprite  = _sprite;

        Initialize();
    }
    public Object(Texture2D _sprite, Transform _transform){
        sprite  = _sprite;
        transform = _transform;

        Initialize();
    }

    public override void Initialize()
    {
        sprite = Globals.s_Level[0];
        physicsBody = new PhysicsBody(transform);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}