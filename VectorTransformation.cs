using System;
using Microsoft.Xna.Framework;

namespace Carpet_Wizard;

public readonly struct VectorTransformation{
    public readonly Vector2 translation;
    public readonly float sin;
    public readonly float cos;

    public VectorTransformation(Vector2 translation, float rotation){
        this.translation = translation;

        this.sin = MathF.Sin(rotation);
        this.cos = MathF.Cos(rotation);
    }
}