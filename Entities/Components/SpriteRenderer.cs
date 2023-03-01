using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class SpriteRenderer : Component
{
    private Transform transform;
    private Texture2D sprite;

    public SpriteRenderer(Entity parentEntity) : base(parentEntity)
    {
        sprite = Globals.s_Misc[0];
        transform = parentEntity.GetComponent<Transform>();
    }
    public SpriteRenderer(Entity parentEntity, Texture2D sprite) : base(parentEntity)
    {
        this.sprite = sprite;
        transform = parentEntity.GetComponent<Transform>();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        SpriteEffects effector = SpriteEffects.None;

        if (transform.GetScale().X < 0){
            effector = SpriteEffects.FlipHorizontally;
        }

        spriteBatch.Draw(sprite, transform.GetPosition(), null, Color.White, transform.GetRotation(), Vector2.Zero, transform.GetScaleABS(), effector, 0);
    }

    public override void Update(GameTime gameTime)
    {}

    public Texture2D GetSprite(){
        return sprite;
    }
    public void SetSprite(Texture2D sprite){
        this.sprite = sprite;
    }
}