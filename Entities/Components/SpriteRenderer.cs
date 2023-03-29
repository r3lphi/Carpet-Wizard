using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class SpriteRenderer : Component
{
    private Transform transform;
    private Texture2D sprite;
    private int layer;

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
    public SpriteRenderer(Entity parentEntity, Texture2D sprite, int layer) : base(parentEntity)
    {
        this.sprite = sprite;
        this.layer = layer;

        transform = parentEntity.GetComponent<Transform>();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        SpriteEffects effector = SpriteEffects.None;

        if (transform.GetScale().X < 0){
            effector = SpriteEffects.FlipHorizontally;
        }

        spriteBatch.Draw(sprite, transform.GetPosition() + new Vector2(sprite.Width / 2, sprite.Height / 2), null, Color.White, transform.GetRotation(), new Vector2(sprite.Width / 2, sprite.Height / 2), transform.GetScaleABS(), effector, layer);
    }

    public override void Update(GameTime gameTime)
    {}

    public Texture2D GetSprite(){
        return sprite;
    }
    public void SetSprite(Texture2D sprite){
        this.sprite = sprite;
    }

    public void SetLayer(int layer){
        this.layer = layer;
    }
}