using System;
using Microsoft.Xna.Framework;

namespace Dynamo
{
    public readonly struct TransformSuggest
    {
        public readonly Vector2 translation;
        public readonly float sin;
        public readonly float cos;

        public readonly static TransformSuggest Zero = new TransformSuggest(0f, 0f, 0f);

        public TransformSuggest(Vector2 translation, float angle)
        {
            this.translation = translation;

            this.sin = MathF.Sin(angle);
            this.cos = MathF.Cos(angle);
        }
        public TransformSuggest(float x, float y, float angle)
        {
            this.translation = new Vector2(x, y);
            
            this.sin = MathF.Sin(angle);
            this.cos = MathF.Cos(angle);
        }
    }
}