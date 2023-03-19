using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        collider.GetComponent<Collider>().SetSize(new Vector2(
            16,
            16
        ));

        activeScreen = new Screen(new List<Entity>{
            player,
            collider
        });
    }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.F4)){
            Globals.DebugMode = true;
        }
        if (Keyboard.GetState().IsKeyUp(Keys.F4)){
            Globals.DebugMode = false;
        }

        activeScreen.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        activeScreen.Draw(spriteBatch);
    }
}