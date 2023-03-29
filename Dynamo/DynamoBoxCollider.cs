using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Carpet_Wizard;

namespace Dynamo;

public class DynamoBoxCollider : DynamoCollider{
    private Vector2 size;

    private readonly Vector2[] vertices;
    private readonly int[] triangles;

    private Vector2[] transformedVertices;

    private bool transformUpdateRequired;

    private Texture2D outline;

    private int debug_padding = 1;

    public DynamoBoxCollider(Entity parentEntity, Transform transform, Vector2 size) : base(ColliderType.Box, transform){
        this.size = size;
        
        vertices = GenVertices(size);
        transformedVertices = new Vector2[vertices.Length];

        triangles = TriangulateBox();

        transformUpdateRequired = true;

        RegenerateOutline(1);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Globals.DebugMode){
            return;
        }

        // ToolsExtended.DrawEmptyRect(
        //     spriteBatch,
        //     (int)transform.GetPosition().X,
        //     (int)transform.GetPosition().Y,
        //     (int)size.X,
        //     (int)size.Y
        // );

        spriteBatch.Draw(outline, transform.GetPosition() + new Vector2(outline.Width / 2, outline.Height / 2), null, Color.White, transform.GetRotation(), new Vector2(outline.Width / 2, outline.Height / 2), Vector2.One, SpriteEffects.None, 1);

        base.Draw(spriteBatch);
    }

    private static Vector2[] GenVertices(Vector2 dim){
        float left = -dim.X / 2;
        float right = left + dim.X;
        float bottom = -dim.Y / 2;
        float top = bottom + dim.Y;

        Vector2[] vertices = new Vector2[4];
        vertices[0] = new Vector2(left, top);
        vertices[1] = new Vector2(right, top);
        vertices[2] = new Vector2(right, bottom);
        vertices[3] = new Vector2(left, bottom);

        return vertices;
    }

    private static int[] TriangulateBox(){
        int[] triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        return triangles;
    }

    public Vector2[] GetTransformedVertices(PhysicsBody body){
        if (transformUpdateRequired){
            TransformSuggest transformation = new TransformSuggest(transform.GetPosition(), body.GetRotation());

            for (int i = 0; i < vertices.Length; i++){
                Vector2 v = vertices[i];
                transformedVertices[i] = DynamoMath.Transform(v, transformation);
            }
        }

        RegenerateOutline(debug_padding);

        return transformedVertices;
    }

    public void SetSize(Vector2 size){
        this.size = size;

        //Centering Code

        // offset -= new Vector2(
        //     (Globals.Tile_Size * ((int)size.X - 1)) / 2,
        //     (Globals.Tile_Size * ((int)size.Y - 1)) / 2
        // );

        RegenerateOutline(debug_padding);
    }
    public Vector2 GetSize(){
        return size;
    }

    public void RequireTransformUpdate(){
        transformUpdateRequired = true;
    }

    private void RegenerateOutline(int padding){
        Vector2 totalSize = size + new Vector2(padding, padding);

        Texture2D texture = new Texture2D(Globals.Graphics.GraphicsDevice, (int)totalSize.X, (int)totalSize.Y);

        Color[] pixelData = new Color[(int)(totalSize.X * totalSize.Y)];

        for (int i = 0; i < totalSize.X; i++){
            pixelData[i] = Color.Red;
            pixelData[(int)((totalSize.X * totalSize.Y) - 1) - i] = Color.Red;
        }
        for (int i = 1; i < totalSize.Y; i++){
            pixelData[(int)(totalSize.X) * i] = Color.Red;
            pixelData[(int)((totalSize.X) * i) - 1] = Color.Red;
        }

        texture.SetData(pixelData);

        outline = ToolsExtended.CreateTexture(Globals.Graphics.GraphicsDevice, (int)totalSize.X, (int)totalSize.Y, pixelData);
    }
}