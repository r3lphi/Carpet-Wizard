using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Tile : Entity
{
    private SpriteRenderer spriteRenderer;
    private Transform transform;

    public Tile(Texture2D sprite){
        AddComponent(new Transform(this));
        AddComponent(new SpriteRenderer(this, sprite));

        Initialize();
    }
    public Tile(Texture2D sprite, Transform transform){
        AddComponent(transform);
        AddComponent(new SpriteRenderer(this, sprite));

        Initialize();
    }

    public override void Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
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
