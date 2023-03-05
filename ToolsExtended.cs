using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace Carpet_Wizard;

public static class ToolsExtended
{
    public static void DrawEmptyRect(SpriteBatch spriteBatch, int x, int y, int width, int height){
        Texture2D DebugLine = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);
        DebugLine.SetData(new[] { Color.Red });

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y,
            width,
            1
        ), null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        
        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y,
            1,
            height
        ), null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X,
            y + (int)Globals.Canvas_Offset.Y + height,
            width,
            1
        ), null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);

        spriteBatch.Draw(DebugLine, new Rectangle(
            x + (int)Globals.Canvas_Offset.X + width,
            y + (int)Globals.Canvas_Offset.Y,
            1,
            height
        ), null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
    }
    public static bool isTouching(Rectangle a, Rectangle b){
        return (
            a.X <= b.X + b.Width &&
            a.X + a.Width >= b.X &&
            a.Y <= b.Y + b.Height &&
            a.Y + a.Height >= b.Y
        );
    }
    public static Rectangle EntityToRect(Entity e){
        Rectangle eRect = new Rectangle(
            new Point(
                (int)(e.GetComponent<Transform>().GetPosition().X + e.GetComponent<Collider>().GetOffset().X),
                (int)(e.GetComponent<Transform>().GetPosition().Y + e.GetComponent<Collider>().GetOffset().Y)
            ),
            new Point(
                (int)(Globals.Tile_Size * e.GetComponent<Collider>().GetBounds().X),
                (int)(Globals.Tile_Size * e.GetComponent<Collider>().GetBounds().Y)
            )
        );

        return eRect;
    }
}