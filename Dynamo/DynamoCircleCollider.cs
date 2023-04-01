using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

using Carpet_Wizard;

namespace Dynamo;

public class DynamoCircleCollider : DynamoCollider{
    private float radius;

    public DynamoCircleCollider(PhysicsBody parentBody, Transform transform) : base(parentBody, ColliderType.Circle, transform){
        radius = 1;
    }
    public DynamoCircleCollider(PhysicsBody parentBody, Transform transform, float radius) : base(parentBody, ColliderType.Circle, transform){
        this.radius = radius;
    }

    public float GetRadius(){
        return radius;
    }
    public void SetRadius(float radius){
        this.radius = radius;
    }
}