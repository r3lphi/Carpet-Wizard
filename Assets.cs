using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class Assets
{
    public static Texture2D PLAYER_IDLE_00;

    public static void Initialize(ContentManager contentManager){
        PLAYER_IDLE_00 = contentManager.Load<Texture2D>("Player_Idle_00");
    }
}