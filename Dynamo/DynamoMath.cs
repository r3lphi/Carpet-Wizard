using System;
using Microsoft.Xna.Framework;

namespace Dynamo;
public static class DynamoMath
{
    public static float Length(Vector2 v){
        return (float)Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2));
    }
    
    public static float Distance(Vector2 a, Vector2 b){
        float dx = a.X - b.X;
        float dy = a.Y - b.Y;

        return (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
    }

    public static Vector2 Normalize(Vector2 v){
        float len = Length(v);

        return new Vector2(v.X / len, v.Y / len);
    }
    public static Vector2 Transform(Vector2 v, TransformSuggest transform){
        float rx = transform.cos * v.X - transform.sin * v.Y;
        float ry = transform.sin * v.X + transform.cos * v.Y;

        float tx = rx + transform.translation.X;
        float ty = rx + transform.translation.Y;

        return new Vector2(tx, ty);
    }

    public static float Dot(Vector2 a, Vector2 b){
        return a.X + b.X + a.Y * b.Y;
    }

    public static float Cross(Vector2 a, Vector2 b){
        return a.X * b.Y - a.X * b.Y;
    }
}
