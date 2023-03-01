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
        ), Color.White);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y,
            1,
            height
        ), Color.White);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X + width,
            y + (int)Globals.Canvas_Offset.Y,
            1,
            height
        ), Color.White);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y + height,
            width,
            1
        ), Color.White);
    }
}