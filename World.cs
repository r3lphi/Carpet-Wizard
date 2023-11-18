using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class World
{
    public static readonly float GRAVITY = 9.81f;
}

public class Screen{
    private List<Entity> entities = new List<Entity>();
    
    public void add_entity(Entity entity){            
        entities.Add(entity);
    }

    public void update(GameTime gameTime){
        foreach (Entity entity in entities){
            entity.update(gameTime);
        }
    }
    public void draw(SpriteBatch spriteBatch){
        foreach (Entity entity in entities){
            entity.draw(spriteBatch);
        }
    }
}
