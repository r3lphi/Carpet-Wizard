using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace Carpet_Wizard;

public static class DebugTools
{
    public static void DrawEmptyRect(SpriteBatch spriteBatch, int x, int y, int width, int height){
        Texture2D DebugLine = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);
        DebugLine.SetData(new[] { Color.White });

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y,
            width,
            1
        ), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        
        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y,
            1,
            height
        ), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y + Globals.Tile_Size,
            width,
            1
        ), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X + Globals.Tile_Size,
            y + (int)Globals.Canvas_Offset.Y,
            1,
            height
        ), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
    }
}