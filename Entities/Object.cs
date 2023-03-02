using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public class Object : Entity
{
    private Transform transform;

    public Object()
    {
        AddComponent(new Transform(this));

        Initialize();
    }

    public override void Initialize()
    {
        transform = GetComponent<Transform>();
    }
}