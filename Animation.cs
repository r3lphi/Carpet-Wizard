using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class AnimationFrame{
    public readonly Texture2D texture;
    public readonly float length;
}
public class Animation{
    public readonly AnimationFrame[] frames;
    private Dictionary<string, bool> flags = new Dictionary<string, bool>();

    public void set(string flag, bool state){
        flags[flag] = state;
    }
    public bool get(string flag){
        return flags[flag];
    }
}
public class Animator : Addon{
    private Animation trackPlaying;
    public bool isPlaying;

    private float timer;
    private int index;

    public override void update(GameTime gameTime)
    {
        timer += (int)gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= trackPlaying.frames.Length){
            index = (index + 1) % trackPlaying.frames.Length;
            timer = 0;
        }
    }

    public override void draw(SpriteBatch spriteBatch){
    }
}