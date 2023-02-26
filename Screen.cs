using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Screen
{
    private List<Entity> entities = new List<Entity>();

    public Screen(List<Entity> startingEntites){
        entities = startingEntites;
    }

    public void Update(GameTime gameTime){
        foreach (Entity e in entities){
            e.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch){
        foreach (Entity e in entities){
            e.Draw(spriteBatch);
        }
    }
}