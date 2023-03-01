using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public class Collider : Component
{
    private Transform transform;
    private PhysicsBody physicsBody;

    public Collider(Entity parentEntity) : base(parentEntity)
    {
        transform = parentEntity.GetComponent<Transform>();
        physicsBody = parentEntity.GetComponent<PhysicsBody>();
    }

    public override void Update(GameTime gameTime)
    {}
    public override void Draw(SpriteBatch spriteBatch)
    {
        DebugTools.DrawEmptyRect(
            spriteBatch,
            (int)transform.GetPosition().X,
            (int)transform.GetPosition().Y,
            16,
            16
        );
    }
}