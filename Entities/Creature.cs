using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public abstract class Creature : Entity
{
    protected Transform transform;
    protected SpriteRenderer spriteRenderer;

    public Creature(){
        AddComponent(new Transform(this));
        AddComponent(new SpriteRenderer(this, null, 1));
    }
    public Creature(Transform transform){
        AddComponent(transform);
    }

    public override void Initialize()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Update(GameTime gameTime)
    {
        GetComponent<PhysicsBody>().Update(gameTime);

        base.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    public void Recenter(){
        GetComponent<Transform>().SetPosition(new Vector2(
            (Globals.Graphics.PreferredBackBufferWidth / 2) - ((spriteRenderer.GetSprite().Width * GetComponent<Transform>().GetScale().X) / 2),
            (Globals.Graphics.PreferredBackBufferHeight / 2) - ((spriteRenderer.GetSprite().Height * GetComponent<Transform>().GetScale().Y) / 2)
        ));
    }
}
