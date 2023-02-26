using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public abstract class Creature : Entity
{
    protected Texture2D sprite;
    protected Transform transform;
    protected PhysicsBody physicsBody;
    protected int direction;

    public override void Update(GameTime gameTime)
    {
        physicsBody.Update();
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        SpriteEffects effector = SpriteEffects.None;

        if (direction == -1){
            effector = SpriteEffects.FlipHorizontally;
        }

        spriteBatch.Draw(sprite, transform.GetPosition(), null, Color.White, transform.GetRotation(), Vector2.Zero, transform.GetScale(), effector, 0);
    }

    public void Recenter(){
        transform.SetPosition(new Vector2(
            (Globals.Graphics.PreferredBackBufferWidth / 2) - ((sprite.Width * transform.GetScale().X) / 2),
            (Globals.Graphics.PreferredBackBufferHeight / 2) - ((sprite.Height * transform.GetScale().Y) / 2)
        ));
    }
}
