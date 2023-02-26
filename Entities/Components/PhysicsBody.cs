using Microsoft.Xna.Framework;

namespace Carpet_Wizard;

public class PhysicsBody
{
    private Transform transform;

    //Physics Logic
    private float gravity = 0f;
    private float friction = 20f;
    
    //Stored Variables
    private Vector2 velocity;

    public PhysicsBody(Transform _transform){
        transform = _transform;

        velocity = Vector2.Zero;
    }

    public void Update()
    {
        velocity.Y += gravity * Globals.DeltaTime;

        transform.SetPosition(transform.GetPosition() + velocity);

        //Horizontal Friction
        velocity.X -= velocity.X * (friction * Globals.DeltaTime);
    }

    public void AddForce(Vector2 force){
        velocity += force;
    }
}