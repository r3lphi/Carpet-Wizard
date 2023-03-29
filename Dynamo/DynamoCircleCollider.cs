using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

using Carpet_Wizard;

namespace Dynamo;

public class DynamoCircleCollider : DynamoCollider{
    private float radius;

    public DynamoCircleCollider(Entity parentEntity, Transform transform) : base(ColliderType.Circle, transform){
        radius = 1;
    }
    public DynamoCircleCollider(Entity parentEntity, Transform transform, float radius) : base(ColliderType.Circle, transform){
        this.radius = radius;
    }

    public float GetRadius(){
        return radius;
    }
    public void SetRadius(float radius){
        this.radius = radius;
    }
}