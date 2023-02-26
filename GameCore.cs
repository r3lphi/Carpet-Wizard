using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Carpet_Wizard;

public class GameCore : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private DisplayHander _display;

    private Screen activeScreen;

    public GameCore()
    {
        _graphics = new GraphicsDeviceManager(this);

        _display = new DisplayHander(_graphics, 640, 360);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Globals.Initialize(Content, _spriteBatch, _graphics);

        Player player = new Player();
        player.Recenter();

        Object snowTile = new Object(Globals.s_Level[0], new Transform(new Vector2(
            (_graphics.PreferredBackBufferWidth / 2) - (Globals.s_Level[0].Width / 2),
            (_graphics.PreferredBackBufferHeight / 2) - (Globals.s_Level[0].Height / 2) + Globals.s_Level[0].Height
        ), 0, Vector2.One));

        activeScreen = new Screen(new List<Entity>{
            player, snowTile
        });

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        if (Keyboard.GetState().IsKeyDown(Keys.F11)){
            _display.ToggleFullscreen();
        }

        // TODO: Add your update logic here
        Globals.Update(gameTime);

        activeScreen.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(_display.GetRenderTarget());
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);

        activeScreen.Draw(_spriteBatch);

        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);

        float renderScale = 1f / ((float)_display.GetPreferredWidth() / GraphicsDevice.Viewport.Width);
        Debug.WriteLine(_display.GetPreferredWidth() + " : " + GraphicsDevice.Viewport.Width + " = Render Scale Of: " + renderScale);

        _spriteBatch.Draw(_display.GetRenderTarget(), Vector2.Zero, null, Color.White, 0f, Vector2.Zero, renderScale, SpriteEffects.None, 0f);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
