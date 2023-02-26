using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public class Collider
{
    private Transform transform;
    private PhysicsBody physicsBody;

    public Collider(Transform _transform, PhysicsBody _physicsBody){
        transform = _transform;
        physicsBody = _physicsBody;
    }

    public void Update(){

    }
    public void Draw(SpriteBatch spriteBatch){
        Texture2D rect = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);
        rect.SetData(new[] { Color.White });

        spriteBatch.Draw(rect, new Rectangle((int)transform.GetPosition().X, (int)transform.GetPosition().Y, 10, 10), Color.Red);
    }
}