using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class PhysicsBody : Component
{
    private Transform transform;

    //Physics Logic
    private float gravity = 0f;
    private float friction = 20f;
    
    //Stored Variables
    private Vector2 velocity;

    public PhysicsBody(Entity parentEntity, Transform _transform) : base(parentEntity)
    {
        transform = _transform;

        velocity = Vector2.Zero;
    }

    public override void Update(GameTime gameTime)
    {
        velocity.Y += gravity * Globals.DeltaTime;

        transform.SetPosition(transform.GetPosition() + velocity);

        //Horizontal Friction
        velocity.X -= velocity.X * (friction * Globals.DeltaTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {}

    public void AddForce(Vector2 force){
        velocity += force;
    }
}