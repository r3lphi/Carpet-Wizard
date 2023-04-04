using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Carpet_Wizard;

public class BoxCollider : Collider{
    public readonly Vector2 size;
    public readonly Vector2 halfSizeOffset;

    public readonly Vector2[] vertices;

    private Vector2[] transformedVertices;
    private bool tVerticesUpdateRequired;

    private Texture2D outline;
    private Color outline_color;

    public BoxCollider(Vector2 offset, Transform transform, Vector2 size) : base(ShapeType.Box, offset, transform){
        this.size = size;
        this.vertices = CreateVertices(new Rectangle(
            (int)transform.GetPosition().X,
            (int)transform.GetPosition().Y,
            (int)size.X,
            (int)size.Y
        ));

        transformedVertices = new Vector2[vertices.Length];

        tVerticesUpdateRequired = true;

        outline_color = Color.Red;

        halfSizeOffset = new Vector2(size.X / 2, size.Y / 2);

        CreateOutline(1);
    }

    public override void Update(GameTime gameTime)
    {
        if (tVerticesUpdateRequired){
            transformedVertices = GetTransformedVertices();
        }

        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Globals.DebugMode){
            return;
        }

        //Drawing Outline
        spriteBatch.Draw(outline, transform.GetPosition() + halfSizeOffset, null, Color.White, transform.GetRotation(), halfSizeOffset, Vector2.One, SpriteEffects.None, 1);

        //Drawing Vertices
        for (int i = 0; i < vertices.Length; i++){
            spriteBatch.Draw(Globals.s_Misc[1], transformedVertices[i] + halfSizeOffset, null, Color.White, 0, halfSizeOffset, Vector2.One, SpriteEffects.None, 1);
        }

        base.Draw(spriteBatch);
    }

    private Vector2[] CreateVertices(Rectangle dims){
        dims.X += (int)offset.X;
        dims.Y += (int)offset.Y;

        Vector2[] vertices = new Vector2[4];

        vertices[0] = new Vector2(dims.X, dims.Y);
        vertices[1] = new Vector2(dims.X, dims.Y + dims.Height);
        vertices[2] = new Vector2(dims.X + dims.Width, dims.Y);
        vertices[3] = new Vector2(dims.X + dims.Width, dims.Y + dims.Height);

        return vertices;
    }

    public Vector2[] GetTransformedVertices(){
        if (tVerticesUpdateRequired){
            Vector2[] transformedVertices = new Vector2[4];

            VectorTransformation transformation = new VectorTransformation(transform.GetPosition(), transform.GetRotation());

            for (int i = 0; i < vertices.Length; i++){
                transformedVertices[i] = VectorMath.Transform(vertices[i], transformation);
            }

            tVerticesUpdateRequired = false;

            return transformedVertices;
        }

        return transformedVertices;
    }

    private void CreateOutline(int padding){
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
    public void SetOutlineColor(Color color){
        outline_color = color;
        CreateOutline(1);
    }

    public void RequireTransformedVerticesUpdate(){
        tVerticesUpdateRequired = true;
    }
}