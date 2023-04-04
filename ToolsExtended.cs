using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
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
                (int)(e.GetComponent<Transform>().GetPosition().X + e.GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().offset.X),
                (int)(e.GetComponent<Transform>().GetPosition().Y + e.GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().offset.Y)
            ),
            new Point(
                (int)e.GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().size.X,
                (int)e.GetComponent<PhysicsBody>().GetColliderAs<BoxCollider>().size.Y
            )
        );

        return eRect;
    }
    public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Color[] paint)
       {
        //initialize a texture
        Texture2D texture = new Texture2D(device, width, height);

        //the array holds the color for each pixel in the texture
        Color[] data = new Color[width * height];
        for(int pixel = 0; pixel < data.Length; pixel++)
        {
            //the function applies the color according to the specified pixel
            data[pixel] = paint[pixel];
        }

        //set the color
        texture.SetData(data);

        return texture;
    }

}