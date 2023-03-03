using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System;

namespace Carpet_Wizard;

public class GameplayState : ProgramState
{
    private Screen activeScreen;

    public override void Initialize()
    {
        Player player = new Player();
        player.Recenter();

        Object collider = new Object();

        collider.AddComponent(new Collider(collider));
        collider.GetComponent<Transform>().SetPosition(player.GetComponent<Transform>().GetPosition());

        collider.GetComponent<Collider>().SetBounds(new Vector2(
            4,
            2
        ));

        activeScreen = new Screen(new List<Entity>{
            player
        });
    }

    public override void Update(GameTime gameTime)
    {
        activeScreen.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        activeScreen.Draw(spriteBatch);
    }
}