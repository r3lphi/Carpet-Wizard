using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public abstract class Creature : Entity
{
    protected Texture2D sprite;
    protected int direction;

    public Creature(){
        AddComponent(new Transform(this));
    }
    public Creature(Transform transform){
        AddComponent(transform);
    }

    public override void Update(GameTime gameTime)
    {
        GetComponent<PhysicsBody>().Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        SpriteEffects effector = SpriteEffects.None;

        if (direction == -1){
            effector = SpriteEffects.FlipHorizontally;
        }

        spriteBatch.Draw(sprite, GetComponent<Transform>().GetPosition(), null, Color.White, GetComponent<Transform>().GetRotation(), Vector2.Zero, GetComponent<Transform>().GetScale(), effector, 0);
    }

    public void Recenter(){
        GetComponent<Transform>().SetPosition(new Vector2(
            (Globals.Graphics.PreferredBackBufferWidth / 2) - ((sprite.Width * GetComponent<Transform>().GetScale().X) / 2),
            (Globals.Graphics.PreferredBackBufferHeight / 2) - ((sprite.Height * GetComponent<Transform>().GetScale().Y) / 2)
        ));
    }
}
