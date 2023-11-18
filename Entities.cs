using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Carpet_Wizard;

public class Entity
{
    public int x, y;
    public Texture2D texture;
    public Vector2 velocity;

    public void update(GameTime gameTime){
        velocity.Y += World.GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        x += (int)velocity.X;
        y += (int)velocity.Y;
    }
    public void draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
    }

    public void move_to_center_of_screen(int screen_width, int screen_height){
        x = (int)((screen_width / 2) - (texture.Width / 2));
        y = (int)((screen_height / 2) - (texture.Height / 2));
    }
}

public abstract class Addon{
    public Entity keeper;

    public abstract void update(GameTime gameTime);
    public abstract void draw(SpriteBatch spriteBatch);
}