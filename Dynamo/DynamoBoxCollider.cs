using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Carpet_Wizard;

namespace Dynamo;

public class DynamoBoxCollider : DynamoCollider{
    private Vector2 size;

    private Vector2[] vertices;
    private Vector2[] transformedVertices;

    private int[] triangles;

    private Texture2D outline;
    
    public Color outline_color = Color.Red;

    private int debug_padding = 1;

    public DynamoBoxCollider(PhysicsBody parentBody, Transform transform, Vector2 size) : base(parentBody, ColliderType.Box, transform){
        this.size = size;
        
        GenVertices(new Rectangle((int)transform.GetPosition().X,
            (int)transform.GetPosition().Y,
            (int)size.X,
            (int)size.Y
        ));
        
        transformedVertices = new Vector2[vertices.Length];

        triangles = TriangulateBox();

        RegenerateOutline(1);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Globals.DebugMode){
            return;
        }

        spriteBatch.Draw(outline, transform.GetPosition() + new Vector2(outline.Width / 2, outline.Height / 2), null, Color.White, transform.GetRotation(), new Vector2(outline.Width / 2, outline.Height / 2), Vector2.One, SpriteEffects.None, 1);

        foreach (Vector2 v in transformedVertices){
            spriteBatch.Draw(Globals.s_Misc[1], v + new Vector2(size.X / 2, size.Y / 2), null, Color.Red, 0, new Vector2(size.X / 2, size.Y / 2), Vector2.One, SpriteEffects.None, 1);
        }

        base.Draw(spriteBatch);
    }

    private void GenVertices(Rectangle dim){
        float left = dim.X;
        float right = dim.X + dim.Width;
        float bottom = dim.Y + dim.Height;
        float top = dim.Y;

        vertices = new Vector2[4];
        vertices[0] = new Vector2(left, top);
        vertices[1] = new Vector2(right, top);
        vertices[2] = new Vector2(right, bottom);
        vertices[3] = new Vector2(left, bottom);
    }

    private int[] TriangulateBox(){
        int[] triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        return triangles;
    }

    public void TransformVertices(){
        TransformSuggest transformation = new TransformSuggest(transform.GetPosition(), transform.GetRotation());

        for (int i = 0; i < vertices.Length; i++){
            transformedVertices[i] = DynamoMath.Transform(vertices[i], transformation);
        }

        RegenerateOutline(debug_padding);
    }
    public Vector2[] GetTransformedVertices(){
        return transformedVertices;
    }

    public void SetSize(Vector2 size){
        this.size = size;

        //Centering Code

        // offset -= new Vector2(
        //     (Globals.Tile_Size * ((int)size.X - 1)) / 2,
        //     (Globals.Tile_Size * ((int)size.Y - 1)) / 2
        // );

        GenVertices(new Rectangle((int)transform.GetPosition().X,
            (int)transform.GetPosition().Y,
            (int)size.X,
            (int)size.Y
        ));

        RegenerateOutline(debug_padding);
    }
    public Vector2 GetSize(){
        return size;
    }

    private void RegenerateOutline(int padding){
        Vector2 totalSize = size + new Vector2(padding, padding);

        Texture2D texture = new Texture2D(Globals.Graphics.GraphicsDevice, (int)totalSize.X, (int)totalSize.Y);

        Color[] pixelData = new Color[(int)(totalSize.X * totalSize.Y)];

        for (int i = 0; i < totalSize.X; i++){
            pixelData[i] = outline_color;
            pixelData[(int)((totalSize.X * totalSize.Y) - 1) - i] = outline_color;
        }
        for (int i = 1; i < totalSize.Y; i++){
            pixelData[(int)(totalSize.X) * i] = outline_color;
            pixelData[(int)((totalSize.X) * i) - 1] = outline_color;
        }

        texture.SetData(pixelData);

        outline = ToolsExtended.CreateTexture(Globals.Graphics.GraphicsDevice, (int)totalSize.X, (int)totalSize.Y, pixelData);
    }
}