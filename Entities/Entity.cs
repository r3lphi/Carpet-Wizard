using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public abstract class Entity
{
    private HashSet<Component> Components = new HashSet<Component>();

    public void AddComponent(Component component){
        Components.Add(component);
    }
    public void RemoveComponent<T>() where T : Component{
        foreach(Component _comp in Components){
            if (_comp.GetType().Equals(typeof(T))){
                Components.Remove(_comp);
            }
        }
    }
    public T GetComponent<T>() where T : Component
    {
        foreach(Component component in Components){
            if (component.GetType().Equals(typeof(T))){
                return (T)component;
            }
        }

        return null;
    }

    public abstract void Initialize();
    
    public virtual void Update(GameTime gameTime){
        foreach(Component _comp in Components){
            _comp.Update(gameTime);
        }
    }
    public virtual void Draw(SpriteBatch spriteBatch){
        foreach(Component _comp in Components){
            _comp.Draw(spriteBatch);
        }
    }
}