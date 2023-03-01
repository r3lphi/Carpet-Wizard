using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public abstract class Component
{
    private Entity parentEntity;

    public Component(Entity parentEntity){
        this.parentEntity = parentEntity;
    }

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    public Entity GetParent(){
        return parentEntity;
    }
    public void SetNewParent(Entity parentEntity){
        this.parentEntity = parentEntity;
    }
}