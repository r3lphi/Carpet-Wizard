using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Carpet_Wizard;

public class Animator : Component
{
    public AnimationBranch[] rootBranches;

    private Texture2D activeSprite;

    public Dictionary<string, int> GlobalDrivers = new Dictionary<string, int>();

    public Animator(Entity parentEntity, AnimationBranch[] _rootBranches) : base(parentEntity)
    {
        rootBranches = _rootBranches;
    }

    public override void Update(GameTime gameTime){
        foreach (AnimationBranch branch in rootBranches){
            branch.Update(GlobalDrivers, this);
        }
    }
    public override void Draw(SpriteBatch spriteBatch)
    {}

    public void SetGlobalDriver(string driver, int value){
        GlobalDrivers[driver] = value;
    }

    public void SetActiveSprite(Texture2D _activeSprite){
        activeSprite = _activeSprite;
    }
    public Texture2D GetActiveSprite(){
        return activeSprite;
    }
}