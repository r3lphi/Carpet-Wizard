using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Carpet_Wizard;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Screen testScreen;
    private Entity player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 320;
        _graphics.PreferredBackBufferHeight = 180;
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        testScreen = new Screen();

        base.Initialize();

        //Make initialization that require assets from LoadContent() down here
        player = new Entity();
        player.texture = Assets.PLAYER_IDLE_00;
        player.move_to_center_of_screen(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

        testScreen.add_entity(player);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Assets.Initialize(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        testScreen.update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        testScreen.draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
