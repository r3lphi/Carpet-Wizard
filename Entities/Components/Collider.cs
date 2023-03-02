using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public class Collider : Component
{
    private Transform transform;
    private PhysicsBody physicsBody;

    private Vector2 oversize_index;

    public Collider(Entity parentEntity) : base(parentEntity)
    {
        transform = parentEntity.GetComponent<Transform>();
        physicsBody = parentEntity.GetComponent<PhysicsBody>();

        oversize_index = Vector2.One;
    }
    public Collider(Entity parentEntity, Vector2 oversize_index) : base(parentEntity)
    {
        transform = parentEntity.GetComponent<Transform>();
        physicsBody = parentEntity.GetComponent<PhysicsBody>();

        this.oversize_index = oversize_index;
    }

    public override void Update(GameTime gameTime)
    {}
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Globals.DebugMode){
            return;
        }

        DebugTools.DrawEmptyRect(
            spriteBatch,
            (int)transform.GetPosition().X,
            (int)transform.GetPosition().Y,
            16 * (int)oversize_index.X,
            16 * (int)oversize_index.Y
        );
    }
}