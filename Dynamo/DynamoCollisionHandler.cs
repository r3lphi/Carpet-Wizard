using System;
using Microsoft.Xna.Framework;
using Carpet_Wizard;

namespace Dynamo{
    public static class DynamoCollisionHandler
    {
        public static bool CirclesIntersect(Vector2 centerA, float radiusA, Vector2 centerB, float radiusB, out Vector2 normal, out float depth){
            normal = Vector2.Zero;
            depth = 0;

            float distance = DynamoMath.Distance(centerA, centerB);
            float radii = radiusA + radiusB;

            if (distance >= radii){
                return false;
            }

            normal = DynamoMath.Normalize(centerB - centerA);
            depth = radii - distance;

            return true;
        }
    }
}