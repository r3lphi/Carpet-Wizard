using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Diagnostics;

namespace Dynamo;

public class DynamoCircleCollider : DynamoCollider{
    private float radius;

    public DynamoCircleCollider(Entity parentEntity) : base(parentEntity, ColliderType.Circle){
        radius = 1;
    }
    public DynamoCircleCollider(Entity parentEntity, float radius) : base(parentEntity, ColliderType.Circle){
        this.radius = radius;
    }

    public float GetRadius(){
        return radius;
    }
    public void SetRadius(float radius){
        this.radius = radius;
    }
}