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

        if (PhysicsBody.CreateBoxBody(collider, collider.GetComponent<Transform>(), new Vector2(Globals.Tile_Size, Globals.Tile_Size) , 1, 0, true, out PhysicsBody body, out string err)){
            collider.AddComponent(body);
        }
        else{
            throw new Exception(err);
        }

        collider.GetComponent<Transform>().SetPosition(player.GetComponent<Transform>().GetPosition());

        activeScreen = new Screen(new List<Entity>{
            player,
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

        // Console.WriteLine(Globals.DebugMode);

        activeScreen.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        activeScreen.Draw(spriteBatch);
    }
}