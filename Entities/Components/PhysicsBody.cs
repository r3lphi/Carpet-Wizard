using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Diagnostics;

namespace Carpet_Wizard;

public class PhysicsBody : Component
{
    private Transform transform;

    private Vector2 velocity;

    private float rotation;
    private float rotationalVelocity;

    public readonly float mass;
    public readonly float density;
    public readonly float restitution;
    public readonly float area;

    public readonly float friction;

    public readonly bool isStatic;

    private Collider collider;

    public static float MIN_BODY_SIZE = 0.01f;
    public static float MAX_BODY_SIZE = float.MaxValue;

    private PhysicsBody(Entity parentEntity, Transform transform, float mass, float density, float restitution, bool isStatic, BoxCollider collider) : base(parentEntity)
    {
        this.transform = transform;

        velocity = Vector2.Zero;
        rotation = 0f;
        rotationalVelocity = 0f;

        friction = 1f;

        this.mass = mass;
        this.density = density;
        this.restitution = restitution;
        this.isStatic = isStatic;
        this.collider = collider;
    }

    // public static bool CreateCircleBody(Entity parentEntity, Transform transform, float radius, float density, float restitution, bool isStatic, out PhysicsBody body, out String err){
    //     body = null;
    //     err = string.Empty;

    //     float area = (float)(Math.Pow(radius, 2) * Math.PI);

    //     if (area < MIN_BODY_SIZE){
    //         err = $"Circle radius does not meet the minimum requirement. Please increase to at least {PhysicsBody.MIN_BODY_SIZE}.";
    //         return false;
    //     }
    //     if (area > MAX_BODY_SIZE){
    //         err = $"Circle radius exceeds the limit. Please reduce to be at most {PhysicsBody.MAX_BODY_SIZE}.";
    //         return false;
    //     }
    //     if (density < Globals.Min_Density){
    //         err = $"Density is too weak. Please increase to at least {Globals.Min_Density}.";
    //         return false;
    //     }
    //     if (density > Globals.Max_Density){
    //         err = $"Density is too strong. Please reduce to be at most {Globals.Max_Density}.";
    //         return false;
    //     }

    //     restitution = Math.Clamp(restitution, 0f, 1f);

    //     float mass = area * density;

    //     body = new PhysicsBody(parentEntity, transform, mass, density, restitution, isStatic, new DynamoCircleCollider(body, transform, radius));

    //     return true;
    // }
    public static bool CreateBoxBody(Entity parentEntity, Transform transform, Vector2 size, Vector2 offset, float density, float restitution, bool isStatic, out PhysicsBody body, out String err){
        body = null;
        err = string.Empty;

        float area = size.X * size.Y;

        if (area < MIN_BODY_SIZE){
            err = $"Box area does not meet the minimum requirement. Please increase to at least {PhysicsBody.MIN_BODY_SIZE}.";
            return false;
        }
        if (area > MAX_BODY_SIZE){
            err = $"Box area exceeds the limit. Please reduce to be at most {PhysicsBody.MAX_BODY_SIZE}.";
            return false;
        }
        if (density < Globals.Min_Density){
            err = $"Density is too weak. Please increase to at least {Globals.Min_Density}.";
            return false;
        }
        if (density > Globals.Max_Density){
            err = $"Density is too strong. Please reduce to be at most {Globals.Max_Density}.";
            return false;
        }

        restitution = Math.Clamp(restitution, 0f, 1f);

        float mass = area * density;

        body = new PhysicsBody(parentEntity, transform, mass, density, restitution, isStatic, new BoxCollider(offset, transform, size));

        return true;
    }

    public override void Update(GameTime gameTime)
    {
        //Gravity
        // AddForce(new Vector2(0, Globals.Gravity * Globals.DeltaTime));

        velocity = VectorMath.Clamp(velocity, -150, -150, 150, 150);

        //Applying Velocity-Based Forces
        transform.SetPosition(transform.GetPosition() + velocity * Globals.DeltaTime);

        rotation += rotationalVelocity * Globals.DeltaTime;

        transform.SetRotation(rotation);

        if (velocity != Vector2.Zero || rotationalVelocity != 0){
            GetColliderAs<BoxCollider>().RequireTransformedVerticesUpdate();
        }

        collider.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        collider.Draw(spriteBatch);
    }

    public void AddForce(Vector2 force){
        velocity += force;
    }
    public void Rotate(float rotation){
        this.rotation += rotation;
    }

    public T GetColliderAs<T>() where T : Collider{
        return (T)collider;
    }

    public float GetRotation(){
        return rotation;
    }
}